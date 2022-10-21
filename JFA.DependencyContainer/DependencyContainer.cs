namespace JFA.DependencyContainer;

public class DependencyContainer : DependencyCollection
{
    public void AddSingleton(Type type) =>
        AddDependency(type, Lifetime.Singleton);

    public void AddScoped(Type type) =>
        AddDependency(type, Lifetime.Scoped);

    public void AddTransient(Type type) =>
        AddDependency(type, Lifetime.Transient);

    public void AddSingleton(Type @interface, Type implementation) =>
        AddDependency(@interface, implementation, Lifetime.Singleton);

    public void AddScoped(Type @interface, Type implementation) =>
        AddDependency(@interface, implementation, Lifetime.Scoped);

    public void AddTransient(Type @interface, Type implementation) =>
        AddDependency(@interface, implementation, Lifetime.Transient);

    public void AddSingleton<T>() where T : class => AddSingleton(typeof(T));

    public void AddScoped<T>() where T : class => AddScoped(typeof(T));

    public void AddTransient<T>() where T : class => AddTransient(typeof(T));

    public void AddSingleton<TInterface, TImplementation>()
        where TImplementation : class, TInterface => 
        AddSingleton(typeof(TInterface), typeof(TImplementation));

    public void AddScoped<TInterface, TImplementation>() 
        where TImplementation : class, TInterface =>
        AddScoped(typeof(TInterface), typeof(TImplementation));

    public void AddTransient<TInterface, TImplementation>() 
        where TImplementation : class, TInterface =>
        AddTransient(typeof(TInterface), typeof(TImplementation));

}