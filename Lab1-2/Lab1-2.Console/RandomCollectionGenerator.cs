namespace Lab1_2.Console;

public static class RandomCollectionGenerator
{
    private static readonly Random Random = new();

    public static IEnumerable<int> GetRandomNumbers(int size)
    {
        return Enumerable.Repeat(0, size).Select(_ => Random.Next());
    }

    public static IEnumerable<int> GetRandomNumbersFromList(IList<int> collection, int size)
    {
        return Enumerable.Repeat(0, size).Select(_ => collection[Random.Next(collection.Count)]);
    }
}