namespace JFA.DependencyContainer;

internal sealed partial class Dependency
{
    public Type Type { get; set; }
    public Lifetime Lifetime { get; set; }
    public Type? ImplementationType { get; set; }
    public object? Implementation { get; set; }
    public bool IsImplemented => Implementation is not null;
}