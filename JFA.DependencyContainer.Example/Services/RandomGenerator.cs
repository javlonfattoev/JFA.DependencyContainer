namespace JFA.DependencyContainer.Example.Services;

public static class RandomGenerator
{
    private const string Source = "1234567890qwertyuiopasdfghjklzxcvbnm";
    private static readonly Random Random = new();

    public static string GetRandomString(int length) => 
        new(Enumerable.Repeat(Source, length)
            .Select(s => s[Random.Next(s.Length)])
            .ToArray());

}