namespace LinkedLists.SinglyLinkedList;

using System.Collections;

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

    public void InsertAt(T value, int index)
    {
        if (head == null || index >= count)
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

        SingleNode<T>? currentNode = head;

        SingleNode<T>? previousNode = head;

        for (int i = 0; i < index; i++)
        {
            previousNode = currentNode;

            currentNode = currentNode?.Next;
        }

        SingleNode<T> newNode = new SingleNode<T>(value);

        SingleNode<T>? tempNextNode = previousNode?.Next;

        previousNode!.Next = newNode;

        newNode.Next = tempNextNode;

        count++;
    }

    public void RemoveAt(int index)
    {
        if (head == null || index >= count)
        {
            return;
        }

        if (index == 0)
        {
            Pop();

            return;
        }

        SingleNode<T>? currentNode = head;

        SingleNode<T>? previousNode = head;

        for (int i = 0; i < index; i++)
        {
            previousNode = currentNode;

            currentNode = currentNode?.Next;
        }

        previousNode!.Next = currentNode?.Next;

        count--;
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

    public int CountIf(Predicate<T> predicate)
    {
        SingleNode<T>? currentNode = head;

        int countMatches = 0;

        for (int i = 0; i < count; i++)
        {
            if (predicate(currentNode!.Value!))
            {
                countMatches++;
            }

            currentNode = currentNode.Next;
        }

        return countMatches;
    }

    public bool Contains(Predicate<T> predicate)
    {
        SingleNode<T>? currentNode = head;

        bool contains = false;

        for (int i = 0; i < count; i++)
        {
            if (predicate(currentNode!.Value!))
            {
                contains = true;
            }

            currentNode = currentNode.Next;
        }

        return contains;
    }

    public void ForEach(Action<T?> function)
    {
        SingleNode<T>? currentNode = head;

        for (int i = 0; i < count; i++)
        {
            function(currentNode!.Value);

            currentNode = currentNode.Next;
        }
    }
}
