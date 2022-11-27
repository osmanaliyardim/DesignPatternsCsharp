/// <summary>
/// Structural Abstract Factory Design Pattern.
/// </summary>

AbstractFactory absFactory1 = new ConcreteFactory1();
Client client1 = new Client(absFactory1);
client1.Run();

AbstractFactory absFactory2 = new ConcreteFactory2();
Client client2 = new Client(absFactory2);
client2.Run();

// Wait for user
Console.ReadLine();

/// <summary>
/// The 'AbstractFactory' abstract class
/// </summary>
abstract class AbstractFactory
{
    public abstract AbstractProductA CreateProductA();

    public abstract AbstractProductB CreateProductB();
}

/// <summary>
/// The 'ConcreteFactory1' class
/// </summary>
class ConcreteFactory1 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA1();
    }

    public override AbstractProductB CreateProductB()
    {
        return new ProductB1();
    }
}

/// <summary>
/// The 'ConcreteFactory2' class
/// </summary>
class ConcreteFactory2 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA2();
    }
    public override AbstractProductB CreateProductB()
    {
        return new ProductB2();
    }
}

/// <summary>
/// The 'AbstractProductA' abstract class
/// </summary>
abstract class AbstractProductA
{
}

/// <summary>
/// The 'AbstractProductB' abstract class
/// </summary>
abstract class AbstractProductB
{
    public abstract void Interact(AbstractProductA productA);
}

/// <summary>
/// The 'ProductA1' class
/// </summary>
class ProductA1 : AbstractProductA
{
}

/// <summary>
/// The 'ProductB1' class
/// </summary>
class ProductB1 : AbstractProductB
{
    public override void Interact(AbstractProductA productA)
    {
        Console.WriteLine(this.GetType().Name +
            " interacts with " +
            productA.GetType().Name);
    }
}

/// <summary>
/// The 'ProductA2' class
/// </summary>
class ProductA2 : AbstractProductA
{
}

/// <summary>
/// The 'ProductB2' class
/// </summary>
class ProductB2 : AbstractProductB
{
    public override void Interact(AbstractProductA productA)
    {
        Console.WriteLine(this.GetType().Name +
            " interacts with " +
            productA.GetType().Name);
    }
}

/// <summary>
/// The 'Client' class. Interaction environment for the products.
/// </summary>
class Client
{
    private AbstractProductA _abstractProductA;
    private AbstractProductB _abstractProductB;

    public Client(AbstractFactory absFactory)
    {
        _abstractProductA = absFactory.CreateProductA();
        _abstractProductB = absFactory.CreateProductB();
    }

    public void Run()
    {
        _abstractProductB.Interact(_abstractProductA);
    }
}