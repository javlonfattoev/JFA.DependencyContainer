namespace JFA.DependencyContainer.Example.Services;

public class TicketService
{
    private readonly TicketRepository _ticketRepository;

    public TicketService(TicketRepository context)
    {
        _ticketRepository = context;
    }

    public string GetTickets => nameof(TicketService) + ":" + _ticketRepository.GetTickets;
}