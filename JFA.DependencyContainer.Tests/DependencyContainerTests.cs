using JFA.DependencyContainer.Example.Services;

namespace JFA.DependencyContainer.Tests;

public class DependencyContainerTests
{
    [Fact]
    public void DependencyContainer_ShouldGetDependency()
    {
        var resolver = new DependencyResolver();
        resolver.Services.AddTransient<AppDbContext>();

        var context = resolver.GetService<AppDbContext>();
        Assert.NotNull(context);
        Assert.IsType("".GetType(), context.Users);
        Assert.True(context != null && context.Users.Contains("Users"));
    }

    [Fact]
    public void DependencyContainer_SingletonShouldReturnSameValue()
    {
        var resolver = new DependencyResolver();
        resolver.Services.AddSingleton<AppDbContext>();

        resolver.Services.AddTransient<TicketRepository>();
        resolver.Services.AddTransient<TicketService>();

        var ticketRepository = resolver.GetService<TicketRepository>();
        var ticketService = resolver.GetService<TicketService>();

        var context1 = resolver.GetService<AppDbContext>();
        var context2 = resolver.GetService<AppDbContext>();

        Assert.Equal(context1.Users, context2.Users);
        Assert.Equal(context1.Tickets, ticketRepository.AppDbContext.Tickets);
        Assert.Equal(ticketRepository.AppDbContext.Tickets, ticketService.AppDbContext.Tickets);
    }

    [Fact]
    public void DependencyContainer_ScopedShouldReturnSameValuePerInstance()
    {
        var resolver = new DependencyResolver();
        resolver.Services.AddScoped<AppDbContext>();
        resolver.Services.AddTransient<TicketRepository>();
        resolver.Services.AddTransient<TicketService>();
        resolver.Services.AddTransient<UsersRepository>();
        resolver.Services.AddTransient<IUsersService, UsersService>();

        var usersService = resolver.GetService<IUsersService>();

        // A scoped service in the process of retrieving a single object should return the same result
        Assert.Equal(usersService.RepositoryTickets, usersService.ServiceTickets);
    }

    [Fact]
    public void DependencyContainer_TransientShouldNotReturnSameValuePerInstance()
    {
        var resolver = new DependencyResolver();
        resolver.Services.AddTransient<AppDbContext>();
        resolver.Services.AddTransient<TicketRepository>();
        resolver.Services.AddTransient<TicketService>();
        resolver.Services.AddTransient<UsersRepository>();
        resolver.Services.AddTransient<IUsersService, UsersService>();

        var usersService = resolver.GetService<IUsersService>();

        // A scoped service in the process of retrieving a single object should return the same result
        Assert.NotEqual(usersService.RepositoryTickets, usersService.ServiceTickets);
    }
}