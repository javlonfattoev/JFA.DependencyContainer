namespace JFA.DependencyContainer.Example.Services;

public class UsersService : IUsersService
{
    private readonly UsersRepository _usersRepository;
    private readonly TicketRepository _ticketRepository;
    private readonly TicketService _ticketService;

    public UsersService(UsersRepository context, TicketRepository ticketRepository, TicketService ticketService)
    {
        _usersRepository = context;
        _ticketRepository = ticketRepository;
        _ticketService = ticketService;
    }

    public string GetUsers() => nameof(UsersService) + ":" + _usersRepository.GetUsers();
    public string GetUserTickets() => nameof(UsersService) + ":" + _ticketService.GetTickets();

    public string RepositoryTickets => _ticketRepository.AppDbContext.Tickets;

    public string ServiceTickets => _ticketService.AppDbContext.Tickets;

}