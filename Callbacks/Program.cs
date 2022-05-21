// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int result = Calculator.SomeLength(new MyProgressReporter());
Console.WriteLine(result);

public class MyProgressReporter : IProgressReporter
{
    public void ReportProgress(int percentDone)
    {
        Console.WriteLine("Percent done " +percentDone );
    }
}

public static class Calculator
{
    public static int SomeLength(IProgressReporter progressReporter)
    {
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(100);
        
            progressReporter.ReportProgress(i);

        } 
           return 42;
    }
 
}
interface IProgressReporter
{
    void ReportProgress(int percentDone);
}