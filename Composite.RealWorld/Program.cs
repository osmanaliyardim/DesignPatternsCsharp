/// <summary>
/// Composite Design Pattern (Real-World)
/// </summary>

CompositeElement root = new CompositeElement("Picture");
root.Add(new PrimitiveElement("Red Line"));
root.Add(new PrimitiveElement("Blue Circle"));
root.Add(new PrimitiveElement("Green Box"));

CompositeElement comp = new CompositeElement("Two Circles");
comp.Add(new PrimitiveElement("Black Circle"));
comp.Add(new PrimitiveElement("White Circle"));

root.Add(comp);

PrimitiveElement primitiveElement = new PrimitiveElement("Yellow Line");
root.Add(primitiveElement);
root.Remove(primitiveElement);

root.Display(1);

Console.ReadLine();

// Child node
public abstract class DrawingElement
{
    protected string _name;

    public DrawingElement(string name)
    {
        _name = name;
    }

    public abstract void Add(DrawingElement drawingElement);

    public abstract void Remove(DrawingElement drawingElement);

    public abstract void Display(int indent);
}

// Parent (Composite)
public class CompositeElement : DrawingElement
{
    List<DrawingElement> elements = new List<DrawingElement>();

    public CompositeElement(string name) : base(name)
    {
    }

    public override void Add(DrawingElement drawingElement)
    {
        elements.Add(drawingElement);
    }

    public override void Remove(DrawingElement drawingElement)
    {
        elements.Remove(drawingElement);
    }

    public override void Display(int indent)
    {
        Console.WriteLine(new String('-', indent) + "+ " + _name);

        foreach (var drawingElement in elements)
        {
            drawingElement.Display(indent + 2);
        }
    }
}

// Leaf node
public class PrimitiveElement : DrawingElement
{
    public PrimitiveElement(string name) : base(name)
    {
    }

    public override void Add(DrawingElement drawingElement)
    {
        Console.WriteLine("Cannot add to a PrimitiveElement");
    }

    public override void Remove(DrawingElement drawingElement)
    {
        Console.WriteLine("Cannot remove from a PrimitiveElement");
    }

    public override void Display(int indent)
    {
        Console.WriteLine(new String('-', indent) + " " + _name);
    }
}