using BenchmarkDotNet.Attributes;
using Lab1_2.List;

namespace Lab1_2.Console;

public class ListBenchmark
{
    private static readonly MyList<int> MyList = new();
    private static readonly List<int> List = new();
    private static readonly LinkedList<int> LinkedList = new();

    static ListBenchmark()
    {
        new ICollection<int>[] { MyList, List, LinkedList }.ToList().ForEach(collection =>
        {
            collection.Add(2);
            collection.Add(5);
            collection.Add(10);
            collection.Add(-10);
            collection.Add(1);
        });
    }

    [Benchmark]
    public void ListAdd() => Add(new List<int>());

    [Benchmark]
    public void LinkedListAdd() => Add(new LinkedList<int>());

    [Benchmark]
    public void MyListAdd() => Add(new MyList<int>());

    [Benchmark]
    public void ListContains() => Contains(new List<int>());

    [Benchmark]
    public void LinkedListContains() => Contains(new LinkedList<int>());

    [Benchmark]
    public void MyListContains() => Contains(new MyList<int>());

    [Benchmark]
    public void ListCopyTo() => CopyTo(new List<int>());

    [Benchmark]
    public void LinkedListCopyTo() => CopyTo(new LinkedList<int>());

    [Benchmark]
    public void MyListCopyTo() => CopyTo(new MyList<int>());

    [Benchmark]
    public void ListRemove() => Remove(new List<int>());

    [Benchmark]
    public void LinkedListRemove() => Remove(new LinkedList<int>());

    [Benchmark]
    public void MyListRemove() => Remove(new MyList<int>());

    [Benchmark]
    public void ListEnumerate() => Enumerate(new List<int>());

    [Benchmark]
    public void LinkedListEnumerate() => Enumerate(new LinkedList<int>());

    [Benchmark]
    public void MyListEnumerate() => Enumerate(new MyList<int>());

    private void Add(ICollection<int> collection) => collection.Add(5);
    private void Contains(ICollection<int> collection) => collection.Contains(5);
    private void CopyTo(ICollection<int> collection) => collection.CopyTo(new int[collection.Count], 0);
    private void Remove(ICollection<int> collection) => collection.Remove(5);

    private void Enumerate(ICollection<int> collection)
    {
        foreach (var item in collection)
        {
            var str = item.ToString();
        }
    }
}