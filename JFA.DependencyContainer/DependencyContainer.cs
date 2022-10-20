namespace JFA.DependencyContainer;

public class DependencyContainer
{
    private readonly List<Dependency> _dependencies;

    public DependencyContainer() =>
        _dependencies = new List<Dependency>();

    public void AddSingleton<T>() =>
        AddDependency<T>(Lifetime.Singleton);

    public void AddTransient<T>() =>
        AddDependency<T>(Lifetime.Transient);

    internal Dependency? GetDependency(Type type) =>
        _dependencies.FirstOrDefault(x => x.Type.Name == type.Name);

    private void AddDependency<T>(Lifetime lifetime) =>
        _dependencies.Add(new Dependency(typeof(T), lifetime));
}