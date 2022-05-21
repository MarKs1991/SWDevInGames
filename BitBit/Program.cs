using System.Drawing;
using System.Drawing.Imaging;

Image ibau = new Image("img/ibau_gross.jpg");
Image hfulogo = new Image("img/hfu.jpg");

Image ibau_sw = new Image(ibau.Width, ibau.Height, PixFmt.L8);

hfulogo.Blt(0, 0, hfulogo.Width, hfulogo.Height, ibau, 20, 20);


ibau.SaveAs("img/out/ibau_mit_logo.jpg");



public enum PixFmt
{
    R8_G8_B8,
    A8_R8_G8_B8,
    L8
}

public class Image
{
    byte[] _pixels;
    public int Width { get; private set; }
    public int Height { get; private set; }

    public PixFmt PixFormat { get; private set; }

    public Image(int width, int height, PixFmt pixFormat)
    {
        Width = width;
        Height = height;
        PixFormat = pixFormat;

        _pixels = new byte[Width * height * BytesPerPixel];
    }

    public Image(string path)
    {
        Bitmap bm = new Bitmap(path);
        Width = bm.Width;
        Height = bm.Height;


        PixFormat = bm.PixelFormat switch
        {
            PixelFormat.Format24bppRgb => PixFmt.R8_G8_B8,
            PixelFormat.Format32bppArgb => PixFmt.R8_G8_B8_A8,
            _ => throw new ArgumentException("unknown pixel")
        };

        _pixels = new byte[Width * Height * BytesPerPixel];

        int bpp = BytesPerPixel;
        switch (PixFormat)
        {

            case PixFmt.R8_G8_B8:
                for (int x = 0; x < Height; x++)
                {
                    for (int y = 0; y < Width; y++)
                    {
                        Color col = bm.GetPixel(x, y);

                        int pixIndex = (y * Width + x) * bpp;
                        _pixels[pixIndex + 0] = col.R;
                        _pixels[pixIndex + 1] = col.G;
                        _pixels[pixIndex + 2] = col.B;
                    }
                }
                break;

            case PixFmt.R8_G8_B8_A8:
                for (int x = 0; x < Height; x++)
                {
                    for (int y = 0; y < Width; y++)
                    {
                        Color col = bm.GetPixel(x, y);

                        int pixIndex = (y * Width + x) * bpp;
                        _pixels[pixIndex + 0] = col.A;
                        _pixels[pixIndex + 1] = col.R;
                        _pixels[pixIndex + 2] = col.G;
                        _pixels[pixIndex + 2] = col.B;
                    }
                }
                break;
        }
    }

    public static void ClipBlt(ref int iSrc, int sizeSrc, int iDst, int sizeDst, ref int sizeBlk)
    {
        int iDeltaL = (iDst < iSrc) ? iDst : iSrc;
        if (iDeltaL > 0)
        {
            iDeltaL = 0;
        }
        int dstRb = iDst + sizeBlk - sizeDst;
        int srcRb = iSrc + sizeBlk - sizeBlk;
        int iDeltaR = (dstRb > srcRb) ? dstRb : srcRb;
        if (iDeltaR < 0)
            iDeltaR = 0;

        iDst -= iDeltaL;
        iSrc -= iDeltaL;
        sizeBlk += iDeltaL;
        sizeBlk -= iDeltaR;
        if (sizeBlk < 0)
            sizeBlk = 0;

    }

    public void Blt(int xSrc, int ySrc, int w, int h, Image dst, int xDst, int yDst)
    {
        ClipBlt(ref xSrc, this.Width, xDst, dst.Width, ref w);
        ClipBlt(ref xSrc, this.Height, xDst, dst.Height, ref h);

        CopyLine copyLine;

        if (PixFormat == dst.PixFormat)
        {
            copyLine = (src, dst, xStartSrc, nPixels, sStartDst) =>
            {
                Array.Copy(src, xStartSrc, dst, sStartDst, nPixels * BytesPerPixel);
            };
        }
        else
        {
            switch (PixFormat)
            {
                case PixFmt.R8_G8_B8:
                    switch (PixFormat)
                    {
                        case PixFmt.A8_R8_G8_B8:
                            break;
                        case PixFmt.L8:
                            break;
                    }


                case PixFmt.A8_R8_G8_B8:
                    switch (PixFormat)
                    {
                        case PixFmt.R8_G8_B8:
                             copyLine = (srcPxl, iSrc, dstPxl, iDst, nPixels) =>
                            {
                                for(int x = 0; x < nPixels; x++)
                                {
                                    int iSrcLine = iSrc + x * (BytesPerPixel);
                                    int col = srcPxl[iSrcLine] * 2;
                                    col += srcPxl[iSrcLine] * 3;
                                    col += srcPxl[iSrcLine+3];
                                    col /= 6;
                                    dst[iDst+ x * dst.BytesPerPixel] = (byte) col;
                                }

                            };

                        case PixFmt.L8:
                            copyLine = (srcPxl, iSrc, dstPxl, iDst, nPixels) =>
                            {
                                for(int x = 0; x < nPixels; x++)
                                {
                                    int iSrcLine = iSrc + x * (BytesPerPixel);
                                    int col = srcPxl[iSrcLine] * 2;
                                    col += srcPxl[iSrcLine] * 3;
                                    col += srcPxl[iSrcLine+3];
                                    col /= 6;
                                    dst[iDst+ x * dst.BytesPerPixel] = (byte) col;
                                }

                            };
                    } break;
                case PixFmt.L8:
                    switch (PixFormat)
                    {
                        case PixFmt.R8_G8_B8:
                            break;
                        case PixFmt.L8:
                            break;
                    }
            }


        }

        for (int y = 0; y < h; y++)
        {
            int xLineSrc = (ySrc + y) * Width * BytesPerPixel;
            int xLineDst = (yDst + y) * dst.Width * dst.BytesPerPixel;
            copyLine(_pixels, dst._pixels, xLineSrc, xLineDst);



        }
    }

    delegate void CopyLine(byte[] src, byte[] dst, int xStartSrc, int nPixels, int sStartDst);



    public int BytesPerPixel => PixFormat switch
    {
        PixFmt.R8_G8_B8 => 3,
        PixFmt.R8_G8_B8_A8 => 4,
        PixFmt.L8 => 1,
        _ => throw new("dont know pixel")
    };



}


