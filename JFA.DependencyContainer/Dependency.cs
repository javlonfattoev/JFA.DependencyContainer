namespace JFA.DependencyContainer;

public class Dependency
{
    public Type Type { get; set; }
    public Lifetime Lifetime { get; set; }
    public object? Implementation { get; set; }
    public bool IsImplemented => Implementation is not null;

    public Dependency(Type type, Lifetime lifetime)
    {
        Type = type;
        Lifetime = lifetime;
    }

    public void AddImplementation(object? implementation) => 
        Implementation = implementation;
}