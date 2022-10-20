namespace JFA.DependencyContainer;

public partial class Dependency
{
    private Dependency(Type type, Lifetime lifetime)
    {
        Type = type;
        Lifetime = lifetime;
    }

    public Type Type { get; set; }
    public Lifetime Lifetime { get; set; }
    public object? Implementation { get; set; }
    public bool IsImplemented => Implementation is not null;
}