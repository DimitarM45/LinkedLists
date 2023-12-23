namespace LinkedLists.SinglyLinkedList;

using static ErrorMessages;

public class SinglyLinkedList<T>
{
    private SingleNode<T>? head;

    private int count;

    public SingleNode<T>? Head => head;

    public int Count => count;

    public void Add(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(NullNodeErrorMessage);
        }

        if (head == null)
        {
            head = new SingleNode<T>(value);
        }
        else
        {
            SingleNode<T>? currentNode = head;

            for (int i = 0; i < Count; i++)
            {
                if (currentNode.Next == null)
                {
                    currentNode.Next = new SingleNode<T>(value);

                    break;
                }

                currentNode = currentNode.Next;
            }
        }

        count++;
    }

    public void Insert(T value, int index)
    {
        if (head == null)
        {
            head = new SingleNode<T>(value);

            return;
        }

        if (index == 0)
        {
            SingleNode<T>? tempHeadNext = head.Next;

            head = new SingleNode<T>(value);

            head.Next = tempHeadNext;

            return;
        }

        SingleNode<T> currentNode = head;

        SingleNode<T> previousNode = head;

        for (int i = 0; i <= index - 1; i++)
        {
            if (currentNode.Next == null)
            {
                currentNode.Next = new SingleNode<T>(value);

                count++;

                return;
            }

            previousNode = currentNode;

            currentNode = currentNode.Next;
        }

        SingleNode<T> newNode = new SingleNode<T>(value);

        SingleNode<T>? tempNextNode = previousNode.Next;

        previousNode.Next = newNode;

        newNode.Next = tempNextNode;

        count++;
    }

    public void Clear()
    {
        head = null;
        count = 0;
    }

    public T? Pop()
    {
        if (head == null)
        {
            return default;
        }

        T? headValue = head.Value;

        if (headValue == null)
        {
            return default;
        }

        SingleNode<T>? nextHead = head.Next;

        if (nextHead == null)
        {
            head = null;

            count--;

            return headValue;
        }

        head = nextHead;

        count--;

        return headValue;
    }

    public T? Peek()
    {
        if (head == null)
        {
            return default;
        }

        return head.Value;
    }
}
