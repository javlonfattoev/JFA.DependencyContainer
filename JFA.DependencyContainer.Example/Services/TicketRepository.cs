namespace JFA.DependencyContainer.Example.Services;

public class TicketRepository
{
    public TicketRepository(AppDbContext context)
    {
        AppDbContext = context;
    }

    public AppDbContext AppDbContext { get; }

    public string GetTickets() => nameof(TicketRepository) + ":" + AppDbContext.Tickets;
}