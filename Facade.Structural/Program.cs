/// <summary>
/// Facade Design Pattern
/// </summary>

Facade facade = new Facade();

facade.MethodA();
facade.MethodB();

// Wait for user
Console.ReadLine();

/// <summary>
/// The 'Subsystem ClassA' class
/// </summary>
public class SubSystemOne
{
    public void MethodOne()
    {
        Console.WriteLine("MethodOne proceed!");
    }
}

/// <summary>
/// The 'Subsystem ClassB' class
/// </summary>
public class SubSystemTwo
{
    public void MethodTwo()
    {
        Console.WriteLine("MethodTwo proceed!");
    }
}

/// <summary>
/// The 'Subsystem ClassC' class
/// </summary>
public class SubSystemThree
{
    public void MethodThree()
    {
        Console.WriteLine("MethodThree proceed!");
    }
}

/// <summary>
/// The 'Subsystem ClassD' class
/// </summary>
public class SubSystemFour
{
    public void MethodFour()
    {
        Console.WriteLine("MethodFor proceed!");
    }
}

/// <summary>
/// The 'Facade' class
/// </summary>
public class Facade
{
    SubSystemOne subSystemOne;
    SubSystemTwo subSystemTwo;
    SubSystemThree subSystemThree;
    SubSystemFour subSystemFour;

    public Facade()
    {
        subSystemOne = new SubSystemOne();
        subSystemTwo = new SubSystemTwo();
        subSystemThree = new SubSystemThree();
        subSystemFour = new SubSystemFour();
    }

    public void MethodA()
    {
        Console.WriteLine("\n Method A -------");
        subSystemOne.MethodOne();
        subSystemTwo.MethodTwo();
        subSystemFour.MethodFour();
    }

    public void MethodB()
    {
        Console.WriteLine("\n Method B -------");
        subSystemTwo.MethodTwo();
        subSystemThree.MethodThree();
    }
}