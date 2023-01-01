/// <summary>
/// Iterator Design Pattern (Real-World)
/// </summary>

Collection collection = new Collection();
collection[0] = new Item("Osman 0");
collection[1] = new Item("Ali 1");
collection[2] = new Item("Yardim 2");
collection[3] = new Item("Belgin 3");
collection[4] = new Item("Ceren 4");
collection[5] = new Item("Ozer 5");
collection[6] = new Item("Berat 6");
collection[7] = new Item("Mehmet 7");
collection[8] = new Item("Topuz 8");

Iterator iterator = collection.CreateIterator();

iterator.Step = 2;

Console.WriteLine("Iterating over collection:");

for (Item item = iterator.First();
    !iterator.IsDone; item = iterator.Next())
{
    Console.WriteLine(item.Name);
}

Console.ReadLine();

public class Item
{
    string _name;

    public Item(string name)
    {
        _name = name;
    }

    public string Name
    {
        get { return _name; }
    }
}

public interface IAbstractCollection
{
    Iterator CreateIterator();
}

public class Collection : IAbstractCollection
{
    List<Item> items = new List<Item>();

    public Iterator CreateIterator()
    {
        return new Iterator(this);
    }

    public int Count { get { return items.Count; } }

    public Item this[int index]
    {
        get { return items[index]; }
        set { items.Add(value); }
    }
}

public interface IAbstractIterator
{
    Item First();

    Item Next();

    bool IsDone { get; }

    Item CurrentItem { get; }
}

public class Iterator : IAbstractIterator
{
    Collection _collection;
    int current = 0;
    int step = 1;

    public Iterator(Collection collection)
    {
        _collection = collection;
    }

    public bool IsDone
    {
        get { return current >= _collection.Count; }
    }

    public Item CurrentItem
    {
        get { return _collection[current] as Item; }
    }

    public Item First()
    {
        current = 0;
        return _collection[current] as Item;
    }

    public Item Next()
    {
        current += step;
        if (!IsDone)
        {
            return _collection[current] as Item;
        }
        else
        {
            return null;
        }
    }

    public int Step
    {
        get { return step; }
        set { step = value; }
    }
}