public abstract class AbstractChatroom
{
    public abstract void Register(Participant participant);
    public abstract void Send(string from, string to, string message);
}

public class Chatroom : AbstractChatroom
{
    private Dictionary<string, Participant> participants = new Dictionary<string, Participant>();

    public override void Register(Participant participant)
    {
        if (!participants.ContainsValue(participant))
        {
            participants[participant.Name] = participant;
        }

        participant.Chatroom = this;
    }

    public override void Send(string from, string to, string message)
    {
        Participant participant = participants[to];

        if (participant != null)
        {
            participant.Receive(from, message);
        }
    }
}

public class Participant
{
    Chatroom chatroom;
    string _name;

    public Participant(string name)
    {
        _name = name;
    }

    public string Name 
    { 
        get { return _name; } 
    }

    public Chatroom Chatroom
    {
        set { chatroom = value; }
        get { return chatroom; }
    }

    public void Send(string to, string message)
    {
        chatroom.Send(_name, to, message);
    }

    public virtual void Receive(string from, string message)
    {
        Console.WriteLine("{0} to {1}: '{2}'", from, Name, message);
    }
}

public class Beatle : Participant
{
    public Beatle(string name) : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.Write("To a Beatle: ");
        base.Receive(from, message);
    }
}

public class NonBeatle : Participant
{
    public NonBeatle(string name) : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.Write("To a Non-Beatle: ");
        base.Receive(from, message);
    }
}