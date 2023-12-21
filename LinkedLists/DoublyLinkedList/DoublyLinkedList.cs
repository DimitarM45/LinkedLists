namespace LinkedLists.DoublyLinkedList;

public class DoublyLinkedList<T>
{
    public DoublyLinkedList()
    {
        Head = new DoubleNode<T>(default);
        Tail = new DoubleNode<T>(default);
    }

    public DoubleNode<T> Head { get; set; }

    public DoubleNode<T> Tail { get; set; }

    public int Count { get; set; }
}
