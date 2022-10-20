namespace JFA.DependencyContainer;

public partial class Dependency
{
    public static Dependency Create(Type type, Lifetime lifetime)
    {
        return new Dependency(type, lifetime);
    }

    public void AddImplementation(object? implementation) =>
        Implementation = implementation;
}