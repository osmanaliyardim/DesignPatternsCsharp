/// <summary>
/// Singleton Design Pattern
/// </summary>

// Constructor is private -- cannot use new
Singleton singleton1 = Singleton.Instance;
Singleton singleton2 = Singleton.Instance;

SingletonTS singletonTS1 = SingletonTS.Instance;
SingletonTS singletonTS2 = SingletonTS.Instance;

// Tests for same instance
if (singleton1 == singleton2)
{
    Console.WriteLine("Objects are the same instance");
}

if (singletonTS1 == singletonTS2)
{
    Console.WriteLine("Objects are the same instance and working as thread safe");
}

// Wait for user
Console.ReadKey();

/// <summary>
/// The 'Singleton' class (NOT Thread Safe)
/// </summary>
public class Singleton
{
    static Singleton instance = null;

    // Constructor is 'private'
    private Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }
    }
}

/// <summary>
/// The 'SingletonTS' class (Thread Safe)
/// </summary>
public class SingletonTS
{
    private static readonly Lazy<SingletonTS> lazy =
        new Lazy<SingletonTS>(() 
            => new SingletonTS());

    public static SingletonTS Instance
    {
        get { return lazy.Value; }
    }

    private SingletonTS()
    {
    }
}