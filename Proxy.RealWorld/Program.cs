/// <summary>
/// Proxy Design Pattern - Real World Example
/// </summary>

MathProxy mathProxy = new MathProxy();

Console.WriteLine(mathProxy.Subtract(10, 2));
Console.WriteLine(mathProxy.Multiply(3, 9));
Console.WriteLine(mathProxy.Add(7, 8));
Console.WriteLine(mathProxy.Divide(27, 9));
Console.WriteLine(mathProxy.Divide(123, 0));

Console.ReadLine();

public interface IMath
{
    public double Add(double x, double y);
    public double Subtract(double x, double y);
    public double Multiply(double x, double y);
    public double Divide(double x, double y);
}

public class Math : IMath
{
    public double Add(double x, double y)
    {
        return x + y;
    }

    public double Divide(double x, double y)
    {
        return x / y;   
    }

    public double Multiply(double x, double y)
    {
        return x * y;
    }

    public double Subtract(double x, double y)
    {
        return x - y;
    }
}

public class MathProxy : IMath
{
    private Math mathObj = new Math();

    public double Add(double x, double y)
    {
        return mathObj.Add(x, y);
    }

    public double Divide(double x, double y)
    {
        if (y == 0)
        {
            Console.Write("Divided by zero exception");
        }

        return mathObj.Divide(x, y);
    }

    public double Multiply(double x, double y)
    {
        return mathObj.Multiply(x, y);
    }

    public double Subtract(double x, double y)
    {
        return mathObj.Subtract(x, y);
    }
}