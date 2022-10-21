namespace JFA.DependencyContainer.Example.Services;

public interface IUsersService
{
    public string GetUsers();
    public string GetUserTickets();
    public string RepositoryTickets { get; }
    public string ServiceTickets { get; }
}