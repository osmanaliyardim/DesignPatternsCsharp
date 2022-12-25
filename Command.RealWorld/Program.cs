/// <summary>
/// Command Design Pattern - Real world example
/// </summary>

User user = new User();

user.Compute('+', 250);
user.Compute('-', 150);
user.Compute('*', 5);
user.Compute('/', 4);

user.Undo(4);

user.Redo(3);

Console.ReadLine();


public abstract class Command
{
    public abstract void Execute();
    public abstract void UnExecute();
}

public class CalculatorCommand : Command
{
    char _operator;
    int _operand;
    Calculator _calculator;

    public CalculatorCommand(Calculator calculator, char @operator, int operand)
    {
        _calculator = calculator;
        _operator = @operator;
        _operand = operand;
    }

    public char Operator 
    {
        set { _operator = value; }
    }

    public int Operand
    {
        set { _operand = value; }
    }

    public override void Execute()
    {
        _calculator.Operation(_operator, _operand);
    }

    public override void UnExecute()
    {
        _calculator.Operation(Undo(_operator), _operand);
    }

    private char Undo(char _operator)
    {
        switch (_operator)
        {
            case '+': return '-';
            case '-': return '+';
            case '*': return '/';
            case '/': return '*';
            default:
                throw new ArgumentException("_operator");
        }
    }
}

public class Calculator
{
    int curr = 0;

    public void Operation(char @operator, int operand)
    {
        switch (@operator)
        {
            case '+': curr += operand; break;
            case '-': curr -= operand; break;
            case '*': curr *= operand; break;
            case '/': curr /= operand; break;
        }
        Console.WriteLine("Current value = {0,3} (following {1} {2})",
            curr, @operator, operand);
    }
}

public class User
{
    Calculator calculator = new Calculator();
    List<Command> commands = new List<Command>();
    int current = 0;

    public void Redo(int levels)
    {
        Console.WriteLine("\n---- Redo {0} levels ", levels);

        for (int i = 0; i < levels; i++)
        {
            if(current < commands.Count - 1)
            {
                Command command = commands[current++];
                command.Execute();
            }
        }
    }

    public void Undo(int levels)
    {
        Console.WriteLine("\n---- Undo {0} levels ", levels);

        for (int i = 0; i < levels; i++)
        {
            if(current > 0)
            {
                Command command = commands[--current] as Command;
                command.UnExecute();
            }
        }
    }

    public void Compute(char @operator, int operand)
    {
        Command command = new CalculatorCommand(calculator, @operator, operand);
        command.Execute();

        commands.Add(command);
        current++;
    }
}