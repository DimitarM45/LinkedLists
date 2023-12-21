namespace DoublyLinkedList.Models;

using System.Collections;

public class SinglyLinkedList<T> : IEnumerable<T>
{
    private int count;

    private Node<T>? Head;

    private Node<T>? Tail;

    public int Count => count;

    public void AddFront(T value)
    {
        if (IsEmpty(Head))
            Head = new Node<T>(value);

        else
        {
            Node<T> node = new Node<T>(value);

            Node<T> tempNode = Head!;

            Head = node;

            Head.Next = tempNode;
        }

        count++;
    }

    public void InsertAt(T value, int index)
    {
        if (index < 0)
            throw new InvalidOperationException("Index cannot be a negative number!");

        if (Count == 0)
            throw new InvalidOperationException("List is emtpy!");

        Node<T>? indexNode;

        Node<T>? tempNode = Head;

        Node<T>? nodeToInsert = new Node<T>(value);

        int counter = -1;

        foreach (T item in this)
        {
            counter++;

            if (counter == index &&
                tempNode != null)
            {
                indexNode = tempNode;

                Node<T>? nextNode = tempNode.Next;

                indexNode.Next = indexNode;

                break;
            }

            tempNode = tempNode!.Next;
        }
    }

    //FIX

    public T? RemoveFront()
    {
        T? value = RemoveFrontOrDefault();

        if (value == null)
            throw new NullReferenceException();

        return value;
    }

    //FIX

    public T? PeekFront()
    {
        T? value = PeekFrontOrDefault();

        if (value == null)
            throw new NullReferenceException();

        return value;
    }

    public T? RemoveFrontOrDefault()
    {
        T? value;

        if (!IsEmpty(Head))
        {
            if (!IsEmpty(Head!.Next))
            {
                value = Head.Next!.Value;

                Node<T> tempNode = Head.Next;

                Head = tempNode;
            }
            else
            {
                value = Head.Value;

                Head = null;
            }

            count--;

            return value!;
        }

        return default!;
    }

    public T? PeekFrontOrDefault()
    {
        if (!IsEmpty(Head))
            return Head!.Value;

        return default!;
    }

    public void Reverse() 
    {

    }

    public void Filter(Predicate<T> condition) 
    {
        
    }

    public void Clear()
    {
        Head = null;

        count = 0;
    }

    private bool IsEmpty(Node<T>? node)
        => node == null;

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? tempNode = Head;

        for (int i = 1; i <= Count; i++)
        {
            if (tempNode != null)
            {
                T value = tempNode.Value;

                yield return value;

                tempNode = tempNode.Next;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
