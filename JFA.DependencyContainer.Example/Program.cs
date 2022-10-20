using JFA.DependencyContainer;
using JFA.DependencyContainer.Example.Services;

var resolver = new DependencyResolver();
resolver.Services.AddTransient<AppDbContext>();
resolver.Services.AddSingleton<TicketRepository>();
resolver.Services.AddTransient<TicketService>();
resolver.Services.AddTransient<UsersRepository>();
resolver.Services.AddTransient<UsersService>();

var ticketService = resolver.GetService<TicketService>();
var usersService = resolver.GetService<UsersService>();

Console.WriteLine(ticketService.GetTickets);
Console.WriteLine(usersService.GetUsers);
Console.WriteLine(usersService.GetUserTickets);