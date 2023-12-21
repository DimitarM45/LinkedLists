namespace DoublyLinkedList.Models;

internal class Node<T>
{
    private T value;

    public Node(T value)
    {
        this.value = value;
    }

    public T Value => value;

    public Node<T>? Next { get; set; }

    public Node<T>? Previous { get; set; }
}
