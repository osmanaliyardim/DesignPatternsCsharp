SortedList studentRecords = new SortedList();

studentRecords.Add("Osman");
studentRecords.Add("Ali");
studentRecords.Add("Berat");
studentRecords.Add("Gokhan");
studentRecords.Add("Belgin");
studentRecords.Add("Ceren");

studentRecords.SetSortStrategy(new QuickSort());
studentRecords.Sort();

studentRecords.SetSortStrategy(new ShellSort());
studentRecords.Sort();

studentRecords.SetSortStrategy(new MergeSort());
studentRecords.Sort();

Console.ReadLine();

public abstract class SortingStrategy
{
    public abstract void Sort(List<string> list);
}

public class QuickSort : SortingStrategy
{
    public override void Sort(List<string> list)
    {
        list.Sort(); // Default will be QuickSort
        Console.WriteLine("QuickSort starts!");
    }
}

public class ShellSort : SortingStrategy
{
    public override void Sort(List<string> list)
    {
        //list.ShellSort(); not-implemented
        Console.WriteLine("ShellSort starts!");
    }
}

public class MergeSort : SortingStrategy
{
    public override void Sort(List<string> list)
    {
        //list.MergeSort(); not implemented
        Console.WriteLine("MergeSort starts!");
    }
}

public class SortedList
{
    private List<string> list = new List<string>();
    private SortingStrategy _sortingStrategy;

    public void SetSortStrategy(SortingStrategy sortingStrategy)
    {
        _sortingStrategy = sortingStrategy;
    }

    public void Add(string name)
    {
        list.Add(name);
    }

    public void Sort()
    {
        _sortingStrategy.Sort(list);

        foreach (var item in list)
        {
            Console.WriteLine(" " + item);
        }

        Console.WriteLine();
    }
}