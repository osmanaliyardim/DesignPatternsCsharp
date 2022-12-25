/// <summary>
/// Command Design Pattern
/// </summary>

// Create receiver, command, and invoker
Receiver receiver = new Receiver();
Command command = new ConcreteCommand(receiver);
Invoker invoker = new Invoker();

// Set and execute command
invoker.SetCommand(command);
invoker.ExecuteCommand();

Console.ReadLine();

/// <summary>
/// The 'Command' abstract class
/// </summary>
public abstract class Command
{
    protected Receiver _receiver;

    public Command(Receiver receiver)
    {
        _receiver = receiver;
    }

    public abstract void Execute();
}

/// <summary>
/// The 'ConcreteCommand' class
/// </summary>
public class ConcreteCommand : Command
{
    public ConcreteCommand(Receiver receiver) : base(receiver)
    {
    }

    public override void Execute()
    {
        _receiver.Action();
    }
}

/// <summary>
/// The 'Receiver' class
/// </summary>
public class Receiver
{
    public void Action()
    {
        Console.WriteLine("Called Receiver.Action()");
    }
}

/// <summary>
/// The 'Invoker' class
/// </summary>
public class Invoker
{
    Command _command;

    public void SetCommand(Command command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
    }
}