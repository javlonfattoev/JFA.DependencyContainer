namespace JFA.DependencyContainer;

internal sealed partial class Dependency
{
    public static Dependency Create(Type type, Lifetime lifetime) => new(type, lifetime);

    public static Dependency Create(Type type, Type implementation, Lifetime lifetime) =>
        new(type, implementation, lifetime);

    private Dependency(Type type) => Type = type;

    private Dependency(Type type, Lifetime lifetime) : this(type) => Lifetime = lifetime;

    private Dependency(Type type, Type implementation, Lifetime lifetime) : this(type, lifetime) => 
        ImplementationType = implementation;

    public void AddImplementation(object? implementation) =>
        Implementation = implementation;
}