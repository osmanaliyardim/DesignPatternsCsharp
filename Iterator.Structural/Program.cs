/// <summary>
/// Iterator Design Pattern (Structural)
/// </summary>

ConcreteAggregate agg = new ConcreteAggregate();
agg[0] = "Osman 1";
agg[1] = "Ali 2";
agg[2] = "Yardim 3";
agg[3] = "Belgin 4";

// Create Iterator and provide aggregate
Iterator it = agg.CreateIterator();

Console.WriteLine("Iterating over collection:");

object item = it.First();

while(item != null)
{
    Console.WriteLine(item);
    item = it.Next();
}

Console.ReadLine();

/// <summary>
/// The 'Aggregate' abstract class
/// </summary>
public abstract class Aggregate
{
    public abstract Iterator CreateIterator();
}

/// <summary>
/// The 'ConcreteAggregate' class
/// </summary>
public class ConcreteAggregate : Aggregate
{
    List<object> items = new List<object>();

    public override Iterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    // Get item count
    public int Count { get { return items.Count; } }

    // Indexer
    public object this[int index]
    {
        get { return items[index]; } 
        set { items.Insert(index, value); }
    }
}

/// <summary>
/// The 'Iterator' abstract class
/// </summary>
public abstract class Iterator
{
    public abstract object First();

    public abstract object Next();
    
    public abstract bool IsDone();

    public abstract object CurrentItem();
}

/// <summary>
/// The 'ConcreteIterator' class
/// </summary>
public class ConcreteIterator : Iterator
{
    ConcreteAggregate _aggregate;
    int current = 0;

    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        _aggregate = aggregate;
    }

    // Gets current iteration item
    public override object CurrentItem()
    {

        return _aggregate[current];
    }

    // Gets first iteration item
    public override object First()
    {
        return _aggregate[0];
    }

    // Gets whether iterations are complete
    public override bool IsDone()
    {
        return current >= _aggregate.Count;
    }

    // Gets next iteration item
    public override object Next()
    {
        object ret = null;

        if(current < _aggregate.Count - 1)
        {
            ret = _aggregate[++current];
        }

        return ret;
    }
}