namespace L02{

    using System;
    using System.Numerics;

public class Program
{
    
    public static void Main(string[] args)
    {
    A someA = new A();
    someA.DoSomething();
    someA = new B();
    someA.DoSomething();
       
    }
}
public class A 
{
    public virtual void DoSomething()
    {
        Console.WriteLine("A");
    }
}
    public class B : A
    {
        public void DoSomething()
        {
            Console.WriteLine("B");
        }
    }



    public class GraficsObject2D
    {
        public virtual double CalcArea()
        {
            return 20;
        }
    }
public class Circle : GraficsObject2D
    {
        public double Width;
        public double Height;

        public override double  CalcArea()
        {
            return Width * Height;

        }
    }
}