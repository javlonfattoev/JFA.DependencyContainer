namespace JFA.DependencyContainer.Example.Services;

public class AppDbContext
{
    public string Users { get; set; }
    public string Tickets { get; set; }

    public AppDbContext()
    {
        Users = "Users: " + RandomGenerator.GetRandomString(6);
        Tickets = "Tickets: " + RandomGenerator.GetRandomString(6);
    }
}