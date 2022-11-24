public sealed class LoadBalancer
{
    private static readonly LoadBalancer instance = new LoadBalancer();

    private readonly List<Server> servers;
    private readonly Random rand = new Random();

    private LoadBalancer()
    {
        servers = new List<Server>
        {
            new Server{ Name = "Osman-Server", IP = "120.14.220.35"},
            new Server{ Name = "Belgin-Server", IP = "120.14.220.34"},
            new Server{ Name = "Ceren-Server", IP = "120.14.220.44"},
            new Server{ Name = "Berat-Server", IP = "120.14.220.31"},
            new Server{ Name = "Gokhan-Server", IP = "120.14.220.06"}
        };
    }

    public static LoadBalancer GetLoadBalancer()
    {
        return instance;
    }

    public Server NextServer
    {
        get
        {
            int r = rand.Next(servers.Count);
            return servers[r];
        }
    }
}

public class Server
{
    public string Name { get; set; }

    public string IP { get; set; }
}