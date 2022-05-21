using System.Collections;

MyContainer<int> integiers = new MyContainer<int>();
//MyContainer<int> integiers = new ();
integiers[1] = 234;
integiers[2] = 12;
integiers[0]= 3123;
integiers[3]= 213;
integiers[4]= 123;


for(int i = 0; i < integiers.length; i++)
{
    Console.WriteLine(integiers.getInt(i));

}

integiers.AddInt(0, 2);
integiers.AddInt(1, 2);
integiers.AddInt(2, 1);
integiers.AddInt(3, 2);
integiers.AddInt(4, 4);

foreach(int ints in integiers)
{
    Console.WriteLine(ints);
}

//for(IEnumerator<> = integiers.AsEnumerable; Enumerable.Move)

//MyContainer<string> theStrings = new MyContainer<string>();

public class MyContainer<T> : IEnumerable<T>
{

    T[] ints;

    int n;

    public int  length => n;


    public MyContainer()
    {
        ints = new T[5];
        n = 0;
    }
   

    public T this [int index]
    {
        set
        {
            AddInt(index, value);
        }
        get
        {
            return getInt(index);
        }
    }
    
    public void AddInt(int index, T anotherInt)
    {
        if(index >= ints.Length)
        {
            int newSize = index < ints.Length * 2 ? ints.Length * 2 : index + 1;

            T[] intsArray = new T[newSize];
            Array.Copy(ints, intsArray, ints.Length);
            ints = intsArray;

        }
        ints[index] = anotherInt;
        n = (index < n) ? n : index + 1;
    }

    public T getInt(int index)
    {
        return ints[index];

    }

    /*public IEnumerator<T> GetEnumerator()
    {
        someEnumarator;
        return someEnumarator;
    }*/
/*
    IEnumerator<T> GetEnumerator()
    {
        return
    }
*/
    public IEnumerator<T> GetEnumerator()
    {
        foreach (T current in ints){
            yield return current;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
         return GetEnumerator();
    }



}

