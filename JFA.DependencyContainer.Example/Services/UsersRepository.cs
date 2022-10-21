namespace JFA.DependencyContainer.Example.Services;

public class UsersRepository
{
    public UsersRepository(AppDbContext context)
    {
        AppDbContext = context;
    }

    public AppDbContext AppDbContext { get; }

    public string GetUsers() => nameof(UsersRepository) + ":" + AppDbContext.Users;
}