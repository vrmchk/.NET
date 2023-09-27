using System.Collections;

namespace Lab1_2.List;

public class NodeEnumerator<T> : IEnumerator<T>
{
    private int _position = -1;
    private readonly Node<T>? _rootNode;
    private Node<T>? _currentNode;

    public NodeEnumerator(Node<T>? rootNode)
    {
        _rootNode = rootNode;
        _currentNode = _rootNode;
    }

    public T Current => _currentNode != null ? _currentNode.Value : default;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_currentNode == null)
            return false;

        if (_position == -1)
        {
            _position++;
            return true;
        }

        if (_currentNode.Next == null)
            return false;

        _currentNode = _currentNode.Next;
        _position++;
        return true;
    }

    public void Reset()
    {
        _currentNode = _rootNode;
        _position = -1;
    }

    public void Dispose() { }
}