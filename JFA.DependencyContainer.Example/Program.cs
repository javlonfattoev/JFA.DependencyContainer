using JFA.DependencyContainer;
using JFA.DependencyContainer.Example.Services;

var resolver = new DependencyResolver();
resolver.Services.AddScoped<AppDbContext>();
resolver.Services.AddTransient<TicketRepository>();
resolver.Services.AddScoped<TicketService>();
resolver.Services.AddTransient<UsersRepository>();
resolver.Services.AddTransient<UsersService>();

var usersService = resolver.GetService<UsersService>();

Console.WriteLine(usersService.GetUsers());
Console.WriteLine(usersService.GetUserTickets());

// with interface
resolver.Services.AddSingleton<IUsersService, UsersService>();
var iUsersService = resolver.GetService<IUsersService>();

Console.WriteLine(iUsersService.GetUserTickets());

