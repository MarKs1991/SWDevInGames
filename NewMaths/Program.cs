// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


struct Vector3 <T> where T : INumber
{
    public T x;
    public T y;
    public T z; 

    public static Vector3<T> operator + (Vector3<T> a; Vector3<T> b)
    {
        return new Vector3<T>{ x = a.x + b.y, y = b.x, z = a.z + a.y};

    }
}

    struct matrix3x3 <T>
    {
        public T m1; 
        public T m2; 
        public static matrix3x3<T> operator * (matrix3x3<T> M, Vector3<T> V)
        {
            return new Vector3<T>();
        }
    }
}
