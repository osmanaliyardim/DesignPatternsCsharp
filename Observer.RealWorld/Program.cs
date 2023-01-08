/// <summary>
/// Observer Design Pattern (Real-world Sample)
/// </summary>

// Create IBM stock and attach investors
IBM ibm = new IBM("IBM", 120.00);
ibm.Attach(new Investor("Sorros"));
ibm.Attach(new Investor("Berkshire"));

// Fluctuating prices will notify investors
ibm.Price = 120.10;
ibm.Price = 121.00;
ibm.Price = 120.50;
ibm.Price = 120.75;

Console.ReadLine();
// -----------------------------------------

public abstract class Stock
{
    private string _symbol;
    private double _price;
    private List<IInvestor> investors = new List<IInvestor>();

    protected Stock(string symbol, double price)
    {
        symbol = symbol;
        price = price;
    }

    public void Attach(IInvestor investor)
    {
        investors.Add(investor);
    }

    public void Detach(IInvestor investor)
    {
        investors.Remove(investor);
    }

    public void Notify()
    {
        foreach (IInvestor investor in investors)
        {
            investor.Update(this);
        }

        Console.WriteLine("");
    }

    public double Price
    {
        get { return _price; }
        set
        {
            if (Price != value)
            {
                _price = value;
                Notify();
            }
        }
    }

    public string Symbol { get { return _symbol; } }
}

public class IBM : Stock
{
    public IBM(string symbol, double price) : base(symbol, price)
    {
    }
}

public interface IInvestor
{
    void Update(Stock stokc);
}

public class Investor : IInvestor
{
    private string _name;
    private Stock stock;

    public Investor(string name)
    {
        _name = name;
    }

    public void Update(Stock stokc)
    {
        Console.WriteLine("Notified {0} of {1}'s change to {2:C}", 
            _name, stock.Symbol, stock.Price);
    }

    public Stock Stock
    {
        get { return stock; }
        set { stock = value; }
    }
}