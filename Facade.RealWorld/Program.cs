// Facade
Mortgage mortgage = new Mortgage();

// Evaluate mortgage eligibility for customer
Customer customer = new Customer("Osman Ali YARDIM");
bool eligible = mortgage.IsEligible(customer, 255000);
Console.WriteLine("\n" + customer.Name +
        " has been " + (eligible ? "Approved" : "Rejected"));

// Wait for user
Console.ReadKey();

public class Bank
{
    public bool HasSufficientSavings(Customer c, int amount)
    {
        Console.WriteLine("Check bank for " + c.Name);
        return true;
    }
}

public class Credit
{
    public bool HasGoodCredit(Customer c)
    {
        Console.WriteLine("Check credit for " + c.Name);
        return true;
    }
}

public class Loan
{
    public bool HasNoBadLoans(Customer c)
    {
        Console.WriteLine("Check loans for " + c.Name);
        return true;
    }
}

public class Customer
{
    private string name;

    public Customer(string name)
    {
        this.name = name;
    }
    public string Name
    {
        get { return name; }
    }
}

public class Mortgage
{
    Bank bank = new Bank();
    Loan loan = new Loan();
    Credit credit = new Credit();
    public bool IsEligible(Customer cust, int amount)
    {
        Console.WriteLine("{0} applies for {1:C} loan\n",
            cust.Name, amount);
        bool eligible = true;

        // Check creditworthyness of applicant
        if (!bank.HasSufficientSavings(cust, amount))
        {
            eligible = false;
        }
        else if (!loan.HasNoBadLoans(cust))
        {
            eligible = false;
        }
        else if (!credit.HasGoodCredit(cust))
        {
            eligible = false;
        }
        return eligible;
    }
}