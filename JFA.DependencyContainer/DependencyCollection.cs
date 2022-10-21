namespace JFA.DependencyContainer;

public class DependencyCollection
{
    private readonly IList<Dependency> _dependencies;

    internal DependencyCollection() =>
        _dependencies = new List<Dependency>();

    internal void AddDependency(Dependency dependency) =>
        _dependencies.Add(dependency);

    internal Dependency? GetDependency(Type type) =>
        _dependencies.FirstOrDefault(x => x.Type.Name == type.Name);

    protected void AddDependency(Type type, Lifetime lifetime) =>
        _dependencies.Add(Dependency.Create(type, lifetime));

    protected void AddDependency(Type @interface, Type implementation, Lifetime lifetime) =>
        _dependencies.Add(Dependency.Create(@interface, implementation, lifetime));
}