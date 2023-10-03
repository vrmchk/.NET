namespace Lab1_2.Console.Benchmarks;

public class CollectionBenchmark<TCollection> : ICollectionBenchmark where TCollection : ICollection<Lazy<int>>, new()
{
    private TCollection _collection = default!;
    private int[] _toRemove = null!;

    public int Count { get; set; }

    public void Setup()
    {
        _collection = new TCollection();
        var values = Enumerable.Range(0, Count).ToArray();
        foreach (var i in values)
        {
            _collection.Add(new Lazy<int>(i));
        }

        _toRemove = values.Take(Count / 10)
            .Union(values.Skip(4 * Count / 10).Take(Count / 10))
            .Union(values.Skip(9 * Count / 10).Take(Count / 10))
            .ToArray();
    }

    public void Add()
    {
        var collection = new TCollection();
        for (var i = 0; i < Count; i++)
        {
            collection.Add(new Lazy<int>(i));
        }
    }

    public void Contains()
    {
        for (var i = 0; i < Count; i++)
        {
            _collection.Contains(new Lazy<int>(i));
        }
    }

    public Lazy<int>[] CopyTo()
    {
        var array = new Lazy<int>[_collection.Count];
        _collection.CopyTo(array, 0);
        return array;
    }

    public void Remove()
    {
        foreach (var item in _toRemove)
        {
            _collection.Remove(new Lazy<int>(item));
        }
    }

    public int Enumerate()
    {
        return _collection.Sum(item => item.Value);
    }
}