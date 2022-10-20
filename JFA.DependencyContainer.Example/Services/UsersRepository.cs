namespace JFA.DependencyContainer.Example.Services;

public class UsersRepository
{
    private readonly AppDbContext _context;

    public UsersRepository(AppDbContext context)
    {
        _context = context;
    }

    public string GetUsers => nameof(UsersRepository) + ":" + _context.Users;
}