namespace JFA.DependencyContainer;

public class DependencyResolver
{
    public readonly DependencyContainer Services;

    public DependencyResolver() => Services = new DependencyContainer();

    public T GetService<T>() => (T)GetService(typeof(T));

    private object GetService(Type type, Type? dependencyType = null)
    {
        DependencyCollection? dependencyCollection = default;
        if (dependencyType == null) dependencyCollection = new DependencyCollection();

        var dependency = Services.GetDependency(type);
        if (dependency is null)
            throw new UnableToResolveException(type, dependencyType);

        if (dependencyType != null && dependency.Lifetime == Lifetime.Scoped)
        {
            var scopedDependency = dependencyCollection?.GetDependency(dependency.Type);
            if (scopedDependency is { IsImplemented: true })
                return scopedDependency.Implementation!;

            dependencyCollection?.AddDependency(dependency);
        }

        var parameters = (dependency.ImplementationType ?? dependency.Type).GetConstructors().Single().GetParameters();

        if (parameters.Length <= 0)
            return CreateImplementation(dependency, Activator.CreateInstance, dependencyType);

        var parameterImplementations = new object?[parameters.Length];

        for (var i = 0; i < parameters.Length; i++)
            parameterImplementations[i] = GetService(parameters[i].ParameterType, dependency.Type);
        
        return CreateImplementation(dependency, t => Activator.CreateInstance(t, parameterImplementations), dependencyType);
    }

    private object CreateImplementation(Dependency dependency, Func<Type, object?> factory, Type? dependencyType = null)
    {
        if (dependency.IsImplemented)
            return dependency.Implementation!;

        object? implementation;

        try
        {
            implementation = factory(dependency.ImplementationType ?? dependency.Type);
        }
        catch (Exception)
        {
            throw new UnableToResolveException(dependency.Type, dependencyType);
        }

        if ((dependencyType != null && dependency.Lifetime == Lifetime.Scoped) || dependency.Lifetime == Lifetime.Singleton)
            dependency.AddImplementation(implementation);

        return implementation!;
    }
}