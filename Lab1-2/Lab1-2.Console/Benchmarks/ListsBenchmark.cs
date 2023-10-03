using BenchmarkDotNet.Attributes;
using Lab1_2.List;

namespace Lab1_2.Console.Benchmarks;

[MemoryDiagnoser]
public class ListsBenchmark
{
    private int _count;
    private readonly ICollectionBenchmark _myListBenchmark;
    private readonly ICollectionBenchmark _listBenchmark;
    private readonly ICollectionBenchmark _linkedListBenchmark;
    private readonly List<ICollectionBenchmark> _benchmarks;

    public ListsBenchmark()
    {
        _myListBenchmark = new CollectionBenchmark<MyList<Lazy<int>>>();
        _listBenchmark = new CollectionBenchmark<List<Lazy<int>>>();
        _linkedListBenchmark = new CollectionBenchmark<LinkedList<Lazy<int>>>();
        _benchmarks = new List<ICollectionBenchmark>
            { _myListBenchmark, _listBenchmark, _linkedListBenchmark };
    }

    [Params(10, 1000, 10000)]
    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            _benchmarks.ForEach(b => b.Count = value);
        }
    }

    [GlobalSetup]
    public void Setup()
    {
        _benchmarks.ForEach(b => b.Setup());
    }

    [Benchmark]
    public void ListAdd() => _listBenchmark.Add();

    [Benchmark]
    public void LinkedListAdd() => _linkedListBenchmark.Add();

    [Benchmark]
    public void MyListAdd() => _myListBenchmark.Add();

    [Benchmark]
    public void ListContains() => _listBenchmark.Contains();

    [Benchmark]
    public void LinkedListContains() => _linkedListBenchmark.Contains();

    [Benchmark]
    public void MyListContains() => _myListBenchmark.Contains();

    [Benchmark]
    public Lazy<int>[] ListCopyTo() => _listBenchmark.CopyTo();

    [Benchmark]
    public Lazy<int>[] LinkedListCopyTo() => _linkedListBenchmark.CopyTo();

    [Benchmark]
    public Lazy<int>[] MyListCopyTo() => _myListBenchmark.CopyTo();

    [Benchmark]
    public void ListRemove() => _listBenchmark.Remove();

    [Benchmark]
    public void LinkedListRemove() => _linkedListBenchmark.Remove();

    [Benchmark]
    public void MyListRemove() => _myListBenchmark.Remove();

    [Benchmark]
    public int ListEnumerate() => _listBenchmark.Enumerate();

    [Benchmark]
    public int LinkedListEnumerate() => _linkedListBenchmark.Enumerate();

    [Benchmark]
    public int MyListEnumerate() => _myListBenchmark.Enumerate();
}