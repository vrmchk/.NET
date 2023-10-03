using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Running;
using Lab1_2.Console;
using Lab1_2.Console.Benchmarks;
using Lab1_2.List;
using static System.Console;

internal static class Program
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
    private static readonly StringBuilder CollectionChangedStringBuilder = new();

    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<ListsBenchmark>();
        
        var size = 10;
        var batchSize = 5;
        var list = new MyList<int>();
        list.CollectionChanged += Collection_Changed;
        
        var numbers = RandomCollectionGenerator.GetRandomNumbers(size).ToList();
        var toFind = RandomCollectionGenerator.GetRandomNumbersFromList(numbers, batchSize)
            .Union(RandomCollectionGenerator.GetRandomNumbers(batchSize)).ToList();
        var toRemove = RandomCollectionGenerator.GetRandomNumbersFromList(numbers, batchSize)
            .Union(RandomCollectionGenerator.GetRandomNumbers(batchSize)).ToList();
        
        numbers.ForEach(list.Add);
        WriteLine($"List: {string.Join(" ", list)}");
        
        WriteLine($"ToFind: {string.Join(" ", toFind)}");
        WriteLine(string.Join(" ", toFind.Select(n => list.Contains(n))));
        
        WriteLine($"ToRemove: {string.Join(" ", toRemove)}");
        toRemove.ForEach(n => list.Remove(n));
        WriteLine($"List: {string.Join(" ", list)}");
        
        WriteLine($"First: {list[0]}");
        list[0] = 0;
        WriteLine($"First: {list[0]}");
        
        var index = list.IndexOf(0);
        WriteLine($"Index of 0: {index}");
        
        list.Insert(0, 1);
        WriteLine($"First: {list[0]}");
        
        list.RemoveAt(0);
        WriteLine($"First: {list[0]}");
        
        var array = new int[list.Count];
        list.CopyTo(array, 0);
        WriteLine($"Array: {string.Join(" ", array)}");
        
        list.Clear();
        WriteLine($"List: {string.Join(" ", list)}");
        
        WriteLine(CollectionChangedStringBuilder.ToString());
    }

    private static void Collection_Changed(CollectionChangedEventArgs<int> args)
    {
        var line = new string('-', 10);
        CollectionChangedStringBuilder.AppendLine(line + args.ChangeType + line);
        CollectionChangedStringBuilder.AppendLine(JsonSerializer.Serialize(args, JsonOptions));
        CollectionChangedStringBuilder.AppendLine();
    }
}