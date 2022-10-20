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

        var context1 = resolver.GetService<AppDbContext>();
        var context2 = resolver.GetService<AppDbContext>();
        Assert.True(string.Equals(context1.Users, context2.Users));
    }
}