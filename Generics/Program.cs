using System.Collections;

MyContainer<int> integiers = new MyContainer<int>();
//MyContainer<int> integiers = new ();
integiers.addSorted(42);
integiers.addSorted(4);
integiers.addSorted(4711);
integiers.addSorted(47);
integiers.addSorted(11);


for(int i = 0; i < integiers.length; i++)
{
    Console.WriteLine(integiers.getInt(i));

}
/*
integiers.AddInt(0, 2);
integiers.AddInt(1, 2);
integiers.AddInt(2, 1);
integiers.AddInt(3, 2);
integiers.AddInt(4, 4);
*/
foreach(int ints in integiers)
{
    Console.WriteLine(ints);
}

//for(IEnumerator<> = integiers.AsEnumerable; Enumerable.Move)

//MyContainer<string> theStrings = new MyContainer<string>();

public class MyContainer<T> : IEnumerable<T> where T : IComparable<T>
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
    
    public void addSorted(T item)
    {
        if ( n >= ints.Length)
        {
            int newSize = n* 2;
            T[] newArray = new T[newSize];
            Array.Copy(ints, newArray, n);
            ints = newArray;
        }
        int i = 0;
        for (; i < n; i++)
        {
            if (item.CompareTo(ints[i]) < 0)
            {
                break;
            }
        }

        Array.Copy(ints, i, ints, i+1, n-1);
        ints[i] = item;
        n++;
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
        for (int i = 0; i <= n; i++)
        {
            yield return ints[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
         return GetEnumerator();
    }

}

