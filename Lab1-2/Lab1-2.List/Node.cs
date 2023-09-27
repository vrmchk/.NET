namespace Lab1_2.List;

public class Node<T> : ICloneable
{
    public Node(T value)
    {
        Value = value;
    }

    public T Value { get; set; }
    public Node<T>? Next { get; set; }

    public object Clone() 
    {
        return new Node<T>(Value) { Next = (Node<T>?)Next?.Clone() };
    }
}