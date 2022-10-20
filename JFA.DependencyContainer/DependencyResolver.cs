namespace JFA.DependencyContainer;

public class DependencyResolver
{
    public readonly DependencyContainer Services;

    public DependencyResolver() => Services = new DependencyContainer();

    public T GetService<T>() => (T)GetService(typeof(T));

    private object GetService(Type type, Type? dependencyType = null)
    {
        var dependency = Services.GetDependency(type);
        if (dependency is null)
            throw new InvalidOperationException(
                $"Unable to resolve service for type '{type}' while attempting to activate '{dependencyType}'.");
        
        var parameters = dependency.Type.GetConstructors().Single().GetParameters();

        if (parameters.Length <= 0) return CreateImplementation(dependency, Activator.CreateInstance);

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
            implementation = factory(dependency.Type);
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Unable to resolve service for type '{dependency.Type}' while attempting to activate '{dependencyType}'.", e);
        }

        if (dependency.Lifetime == Lifetime.Singleton)
            dependency.AddImplementation(implementation);

        return implementation!;
    }
}