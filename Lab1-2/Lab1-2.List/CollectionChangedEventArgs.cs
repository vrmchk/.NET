namespace Lab1_2.List;

public class CollectionChangedEventArgs<T> : EventArgs
{
    public CollectionChangeType ChangeType { get; set; }
    public T? OldItem { get; set; }
    public T? NewItem { get; set; }
    public ICollection<T> OldCollection { get; set; } = new List<T>();
    public ICollection<T> NewCollection { get; set; } = new List<T>();
}