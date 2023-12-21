namespace LinkedLists.SinglyLinkedList;

public class SinglyLinkedList<T>
{
    private SingleNode<T>? head;

    public SingleNode<T>? Head => head;

    public int Count { get; set; }

    public void Clear()
    {
        Head = null;
        Count = 0;
    }

    public void Add(SingleNode<T> node)
    {
        if (head == null)
        {
            head = node;
        }
        else if (head.Next == null)
        {

            head.Next = node;
        }
        else
        {
            SingleNode<T>? currentNode = head;

            for (int i = 0; i < Count; i++)
            {
                currentNode = currentNode?.Next;
            }

            currentNode!.Next = node;
        }

        Count++;
    }
}
