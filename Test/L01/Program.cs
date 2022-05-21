namespace Test{

    using System.Globalization;
    using System.Numerics;

public class Program{
    
    public static void Main(string[] args)
    {
/*
        int i = 42;
        object o = i;
        o = 43;
        int j = (int)o;
        Console.WriteLine("i is: " + i + "; o is: " + o + "; j is: " + j);
*/

       VectorGen a = new VectorGen();
        //a.createVector();
        a.createVectorByStruct();
    }

public class VectorGen
{
    int length = 10000;
    public void createVector()
    {
              DateTime startTime = DateTime.Now;

        
        Vector3[] VectorArray = new Vector3[length];
        for (int i = 0; i < length; i++)
        {
            Random rnd = new Random();

                var x = rnd.Next(1,100);
                var y = rnd.Next(1,100);
                var z = rnd.Next(1,100);

            Vector3 v1 = new Vector3(x, y, z);
            VectorArray[i] = v1;
            
        }

        for (int i = 0; i < length; i++)
        {
             Console.WriteLine("x: " + VectorArray[i].x + "y: "+ VectorArray[i].y + "z: " + VectorArray[i].z);
             //int x = VectorArray[i].x;
             //int y = VectorArray[i].y;
             //int z = VectorArray[i].z;
        }
        DateTime endTime = DateTime.Now;
        float time = (endTime.Ticks - startTime.Ticks) / 10000000f;
        Console.WriteLine(time);
        //Vector3 v1 = new Vector3{x = 1, y = 4, z = 3};

     
    }
    public void createVectorByStruct()
    {

        DateTime startTime = DateTime.Now;      

         Vertex[] VectorArray = new Vertex[length];
       for (int i = 0; i < length; i++)
        {
            Random rnd = new Random();

                var x = rnd.Next(1,100);
                var y = rnd.Next(1,100);
                var z = rnd.Next(1,100);

            Vertex v1 = new Vertex{ Position = new float3(x,y,z), Normal = new float3(x,y,z), UVW = new float3(x,y,z)};
            VectorArray[i] = v1;
            
        }

        for (int i = 0; i < length; i++)
        {
             Console.WriteLine("x: " + VectorArray[i].Position + "y: "+ VectorArray[i].Normal + "z: " + VectorArray[i].UVW);
            float y1 = VectorArray[500].Position.x;
        }

        DateTime endTime = DateTime.Now;
        float time = (endTime.Ticks - startTime.Ticks) / 10000000f;
        Console.WriteLine(time);
    }

}
    public class Vector3 {
        public float x;
        public float y;
        public float z;

        public Vector3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    public struct Vert{
        float x;
        float y;
    }
    public struct Vertex
    {
        public float3 Position; 
        public float3 Normal;
        public float3 UVW;
    }
    public class float3 
    {
        public float x;
        public float y;
        public float z;

         public float3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
}
