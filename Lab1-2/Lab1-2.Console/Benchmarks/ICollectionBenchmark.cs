namespace Lab1_2.Console.Benchmarks;

public interface ICollectionBenchmark
{
    int Count { get; set; }
    void Setup();
    void Add();
    void Contains();
    Lazy<int>[] CopyTo();
    void Remove();
    int Enumerate();
}