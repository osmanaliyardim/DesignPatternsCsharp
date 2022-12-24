/// <summary>
/// Proxy Design Pattern
/// </summary>

Proxy proxy = new Proxy();
proxy.Request();

Console.ReadLine();

/// <summary>
/// The 'Subject' abstract class
/// </summary>
public abstract class Subject
{
    public abstract void Request();
}

/// <summary>
/// The 'RealSubject' class
/// </summary>
public class RealSubject : Subject
{
    public override void Request()
    {
        Console.WriteLine("This request goes to RealSubject");
    }
}

/// <summary>
/// The 'Proxy' class
/// </summary>
public class Proxy : Subject
{
    private RealSubject realSubject;

    public override void Request()
    {
        // Use 'lazy initialization'

        if(realSubject == null)
        {
            realSubject = new RealSubject();
        }

        realSubject.Request();
    }
}