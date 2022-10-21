namespace JFA.DependencyContainer;

public class DependencyContainer : DependencyCollection
{
    public void AddSingleton<T>() where T : class =>
        AddDependency<T>(Lifetime.Singleton);
    
    public void AddScoped<T>() where T : class =>
        AddDependency<T>(Lifetime.Scoped);

    public void AddTransient<T>() where T : class =>
        AddDependency<T>(Lifetime.Transient);

    public void AddSingleton<TInterface, TImplementation>() 
        where TImplementation : class, TInterface =>
        AddDependency<TInterface, TImplementation>(Lifetime.Singleton);

    public void AddScoped<TInterface, TImplementation>() 
        where TImplementation : class, TInterface =>
        AddDependency<TInterface, TImplementation>(Lifetime.Singleton);

    public void AddTransient<TInterface, TImplementation>() 
        where TImplementation : class, TInterface =>
        AddDependency<TInterface, TImplementation>(Lifetime.Singleton);
}