/// <summary>
/// Strategy Design Pattern
/// </summary>

Context context;

// Three contexts following different strategies
context = new Context(new ConcreteStrategyA());
context.ContextInterface();

context = new Context(new ConcreteStrategyB());
context.ContextInterface();

context = new Context(new ConcreteStrategyC());
context.ContextInterface();

// Wait for user
Console.ReadKey();

/// <summary>
/// The 'Strategy' base class
/// </summary>
public abstract class Strategy
{
    public abstract void AlgorithmInterface();
}

/// <summary>
/// A 'ConcreteStrategy' class
/// </summary>
public class ConcreteStrategyA : Strategy
{
    public override void AlgorithmInterface()
    {
        Console.WriteLine("Called ConcreteStrategyA.AlgorithmInterface()");
    }
}

/// <summary>
/// B 'ConcreteStrategy' class
/// </summary>
public class ConcreteStrategyB : Strategy
{
    public override void AlgorithmInterface()
    {
        Console.WriteLine("Called ConcreteStrategyB.AlgorithmInterface()");
    }
}

/// <summary>
/// C 'ConcreteStrategy' class
/// </summary>
public class ConcreteStrategyC : Strategy
{
    public override void AlgorithmInterface()
    {
        Console.WriteLine("Called ConcreteStrategyC.AlgorithmInterface()");
    }
}

/// <summary>
/// The 'Context' class
/// </summary>
public class Context
{
    Strategy _strategy;

    public Context(Strategy strategy)
    {
        _strategy = strategy;
    }

    public void ContextInterface()
    {
        _strategy.AlgorithmInterface();
    }
}