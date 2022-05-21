namespace L02{

    using System;
    using System.Numerics;

public class Program
{
    
    public static void Main(string[] args)
    {
    IGraficsObject3D someA = new Circle{Width = 20, Height = 10};
    //someA.DoSomething();
    //someA = new B();
    
    Console.WriteLine(someA.CalcArea());
       
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
        public override void DoSomething()
        {
            Console.WriteLine("B");
        }
    }



    interface IGraficsObject3D
    {
        //public string name;
        int s { get; set;}
        double CalcArea(){
            Console.WriteLine("aa");
            return 4;
        }
    
        
    }
    

    public abstract class AbstractGraficsObject3D
    {
        public int s;
        public abstract double CalcArea();          
    }

public class Circle : IGraficsObject3D
    {
        public int s { get; set;}
        public double Width;
        public double Height;       
        /*
        public double CalcArea()
        {
            return 10;
        }
        */
    }
    public class Circle2 : Circle
    {
        public int s { get; set;}
        public double Width;
        public double Height;       
        public double CalcArea()
        {
            return 20;

        }
    }

    
}