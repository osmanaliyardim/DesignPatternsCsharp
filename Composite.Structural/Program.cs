/// <summary>
/// Composite Design Pattern (Structural)
/// </summary>

// Create a tree structure
Composite root = new Composite("root");
root.Add(new Leaf("Leaf A"));
root.Add(new Leaf("Leaf B"));

Composite comp = new Composite("Composite X");
comp.Add(new Leaf("Leaf XA"));
comp.Add(new Leaf("Leaf XB"));

root.Add(comp);

root.Add(new Leaf("Leaf C"));

// Add and remove a leaf
Leaf leaf = new Leaf("Leaf D");
root.Add(leaf);
root.Remove(leaf);

// Recursively display tree
root.Display(1);

Console.ReadLine();


/// <summary>
/// The 'Component' abstract class (Child)
/// </summary>
public abstract class Component
{
    protected string _name;

    public Component(string name)
    {
        _name = name;
    }

    public abstract void Add(Component component);

    public abstract void Remove(Component component);

    public abstract void Display(int depth);
}

/// <summary>
/// The 'Composite' class (Parent)
/// </summary>
public class Composite : Component
{
    List<Component> children = new List<Component>();

    public Composite(string name) : base(name)
    { 
    }

    public override void Add(Component component)
    {
        children.Add(component);
    }

    public override void Remove(Component component)
    {
        children.Remove(component);
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + _name);

        // Recursively display child nodes
        foreach (var componenat in children)
        {
            componenat.Display(depth + 2);
        }
    }
}

/// <summary>
/// The 'Leaf' class
/// </summary>
public class Leaf : Component
{
    public Leaf(string name) : base(name)
    {
    }

    public override void Add(Component component)
    {
        Console.WriteLine("Cannot add to a leaf");
    }

    public override void Remove(Component component)
    {
        Console.WriteLine("Cannot remove from a leaf");
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + _name);
    }
}