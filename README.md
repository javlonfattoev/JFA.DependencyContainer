# JFA.DependencyContainer
> Dependency Container is an object that knows how to instantiate and configure objects. And to be able to do its job, it needs to knows about the constructor arguments and the relationships between the objects
#
>Install package from [nuget.org](https://www.nuget.org/packages/JFA.DependencyContainer)
```C#
NuGet\Install-Package JFA.DependencyContainer -Version <VERSION>
```
#

```C#
var resolver = new DependencyResolver();

resolver.Services.AddSingleton<AppDbContext>();
resolver.Services.AddTransient<TicketRepository>();
resolver.Services.AddScoped<TicketService>();

var ticketService = resolver.GetService<TicketService>();
```
#
>register services [with attributes](https://www.nuget.org/packages/JFA.DependencyInjection)
```C#
builder.Services.AddServicesFromAttribute();
```
#
> with interface
```C#
resolver.Services.AddSingleton<IUsersService, UsersService>();
var usersService = resolver.GetService<IUsersService>();

Console.WriteLine(usersService.GetUserTickets());
```
