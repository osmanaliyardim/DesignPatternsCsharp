/// <summary>
/// Mediator Design Pattern
/// </summary>
ConcreteMediator mediator = new ConcreteMediator();

ConcreteColleague1 colleague1 = new ConcreteColleague1(mediator);
ConcreteColleague2 colleague2 = new ConcreteColleague2(mediator);

mediator.Colleague1 = colleague1;
mediator.Colleague2 = colleague2;

colleague1.Send("How are you?");
colleague2.Send("Fine, thanks");

// Wait for user
Console.ReadLine();

/// <summary>
/// The 'Mediator' abstract class
/// </summary>
public abstract class Mediator
{
    public abstract void Send(string message, Colleague colleague);
}

/// <summary>
/// The 'ConcreteMediator' class
/// </summary>
public class ConcreteMediator : Mediator
{
    ConcreteColleague1 colleague1;
    ConcreteColleague2 colleague2;

    public ConcreteColleague1 Colleague1
    {
        set { colleague1 = value; }
    }

    public ConcreteColleague2 Colleague2
    {
        set { colleague2 = value; }
    }

    public override void Send(string message, Colleague colleague)
    {
        if (colleague == colleague1)
        {
            colleague2.Notify(message);
        }
        else
        {
            colleague1.Notify(message);
        }
    }
}

/// <summary>
/// The 'Colleague' abstract class
/// </summary>
public abstract class Colleague
{
    protected Mediator _mediator;

    protected Colleague(Mediator mediator)
    {
        _mediator = mediator;
    }
}

/// <summary>
/// A 'ConcreteColleague' class
/// </summary>
public class ConcreteColleague1 : Colleague
{
    public ConcreteColleague1(Mediator mediator) : base(mediator)
    {
    }

    public void Send(string message)
    {
        _mediator.Send(message, this);
    }

    public void Notify(string message)
    {
        Console.WriteLine("Colleague1 gets message: " + message);
    }
}

/// <summary>
/// A 'ConcreteColleague' class
/// </summary>
public class ConcreteColleague2 : Colleague
{
    public ConcreteColleague2(Mediator mediator) : base(mediator)
    {
    }

    public void Send(string message)
    {
        _mediator.Send(message, this);
    }

    public void Notify(string message)
    {
        Console.WriteLine("Colleague2 gets message: " + message);
    }
}