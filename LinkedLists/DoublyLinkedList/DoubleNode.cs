namespace LinkedLists.DoublyLinkedList;

public class DoubleNode<T>
{
    public DoubleNode(T? value)
    {
        Value = value;
    }

    public T? Value { get; set; }

    public DoubleNode<T>? Next { get; set; }

    public DoubleNode<T>? Previous { get; set; }
}
