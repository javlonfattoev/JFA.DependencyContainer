namespace JFA.DependencyContainer.Example.Services;

public class TicketService
{
    private readonly TicketRepository _ticketRepository;
    private readonly AppDbContext _appDbContext;

    public TicketService(TicketRepository context, AppDbContext appDbContext)
    {
         _appDbContext = appDbContext;
        _ticketRepository = context;
    }

    public AppDbContext AppDbContext => _ticketRepository.AppDbContext;
    public string GetTickets() => nameof(TicketService) + ":" + _ticketRepository.GetTickets();
}