namespace JFA.DependencyContainer;

public class UnableToResolveException : Exception
{
    public UnableToResolveException(Type type, Type? dependencyType) :
        base($"Unable to resolve service for type '{type}' while attempting to activate '{dependencyType}'.")
    { }

    public UnableToResolveException(Type type) :
        base($"Unable to resolve service for type '{type}'.")
    { }
}