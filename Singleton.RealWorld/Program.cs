LoadBalancer balancer1 = LoadBalancer.GetLoadBalancer();
LoadBalancer balancer2 = LoadBalancer.GetLoadBalancer();
LoadBalancer balancer3 = LoadBalancer.GetLoadBalancer();

if (balancer1 == balancer2 && balancer2 == balancer3 && balancer3 == balancer1)
{
    Console.WriteLine("Same instance detected!\n");
}

LoadBalancer balancer = LoadBalancer.GetLoadBalancer();

for (int i = 0; i < 15; i++)
{
    string server = balancer.Server;
    Console.WriteLine("Dispatch request to: " + server);
}

Console.ReadLine();

public class LoadBalancer
{
    static LoadBalancer instance;
    List<string> servers = new List<string>();
    Random rand = new Random();

    private static object locker = new object();

    protected LoadBalancer()
    {
        servers.Add("Osman-Server");
        servers.Add("Ali-Server");
        servers.Add("Belgin-Server");
        servers.Add("Ceren-Server");
        servers.Add("Berat-Server");
        servers.Add("Gokhan-Server");
    }

    public static LoadBalancer GetLoadBalancer() 
    { 
        if (instance == null)
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new LoadBalancer();
                }
            }
        }

        return instance;
    }
    
    public string Server
    {
        get
        {
            int r = rand.Next(servers.Count);
            return servers[r].ToString();
        }
    }
}