namespace LinkedLists.SinglyLinkedList;

public class SingleNode<T>
{
    public SingleNode(T? value)
    {
        Value = value;
    }

    public T? Value { get; set; }

    public SingleNode<T>? Next { get; set; }
}
