namespace JFA.DependencyContainer.Example.Services;

public class UsersService
{
    private readonly UsersRepository _usersRepository;
    private readonly TicketRepository _ticketRepository;

    public UsersService(UsersRepository context, TicketRepository ticketRepository)
    {
        _usersRepository = context;
        _ticketRepository = ticketRepository;
    }

    public string GetUsers => nameof(UsersService) + ":" + _usersRepository.GetUsers;
    public string GetUserTickets => nameof(UsersService) + ":" + _ticketRepository.GetTickets;
}