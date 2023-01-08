/// <summary>
/// Observer Design Pattern (Structural)
/// </summary>

// Configure Observer Pattern
ConcreteSubject subject = new ConcreteSubject();

subject.Attach(new ConcreteObserver(subject, "Osman"));
subject.Attach(new ConcreteObserver(subject, "Ali"));
subject.Attach(new ConcreteObserver(subject, "Belgin"));

// Change subject and notify observers
subject.SubjectState = "ABC";
subject.Notify();

Console.ReadLine();

/// <summary>
/// The 'Subject' abstract class
/// </summary>
public abstract class Subject
{
    private List<Observer> observers = new List<Observer>();

    public void Attach(Observer observer)
    {
        observers.Add(observer);
    }

    public void Detach(Observer observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (Observer observer in observers)
        {
            observer.Update();
        }
    }
}

/// <summary>
/// The 'ConcreteSubject' class
/// </summary>
public class ConcreteSubject : Subject
{
    private string subjectState;

    // Gets or sets subject state
    public string SubjectState
    {
        get { return subjectState; }
        set { subjectState = value; }
    }
}

/// <summary>
/// The 'Observer' abstract class
/// </summary>
public abstract class Observer
{
    public abstract void Update();
}

/// <summary>
/// The 'ConcreteObserver' class
/// </summary>
public class ConcreteObserver : Observer
{
    private string _name;
    private string observerState;
    private ConcreteSubject _subject;

    public ConcreteObserver(ConcreteSubject subject, string name)
    {
        subject = subject;
        name = name;
    }

    public override void Update()
    {
        observerState = _subject.SubjectState;
        Console.WriteLine("Observer {0}'s new state is {1}", _name, observerState);
    }

    // Gets or sets subject
    public ConcreteSubject Subject 
    { 
        get { return _subject; }
        set { _subject = value; }
    }
}