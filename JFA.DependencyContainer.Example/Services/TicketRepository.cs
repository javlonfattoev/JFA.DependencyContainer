namespace JFA.DependencyContainer.Example.Services;

public class TicketRepository
{
    private readonly AppDbContext _context;

    public TicketRepository(AppDbContext context)
    {
        _context = context;
    }

    public string GetTickets => nameof(TicketRepository) + ":" + _context.Tickets;
}