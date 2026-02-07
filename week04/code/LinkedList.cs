using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only tail will be affected.
        else
        {
            newNode.Prev = _tail; // Connect new node to the next tail
            _tail.Next = newNode; // Connect the next tail to the new node
            _tail = newNode; // Update the head to point to the new node
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the tail
        // will be affected.
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null; // Disconnect the penultimate node from the last node
            _tail = _tail.Prev; // Update the tail to point to the penultimate node
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // I created a new variable in order to iterate through the list, 
        // assigning this variable to the head of the list
        var current = _head;

        // If there is only one value in the list, this means that this value is going to be deleted, therefore, 
        // I assigned both head and tail to null, thus removing de value
        if (current?.Prev == null && current?.Next == null)
        {
            _head = null;
            _tail = null;
            return;
        }

        // I iterate through the entire list, begining by the head,
        // if I find the value to be removed, I call RemoveHead if the previous value is null
        // and I call RemoveTail if the next value is null,
        // If both the next and previous values aren't null, I assign the next node Prev to the previous node from current
        // and the previous node Next to the next node from current, thus removind the desired node.
        while (current != null)
        {
            if (current.Data == value)
            {
                if (current.Prev == null)
                {
                    RemoveHead();
                    return;
                }
                else if (current.Next == null)
                {
                    RemoveTail();
                    return;
                }
                else
                {
                    current.Next!.Prev = current.Prev;
                    current.Prev!.Next = current.Next;
                    return;
                }
            }

            // Continues iterating through the list
            else
            {
                current = current.Next;
            }

            // If it gets to the end of the list and doesn't find the value to be removed, returns
            if (current == _tail && current?.Data != value)
            {
                return;
            }
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // I created a new variable in order to iterate through the list, 
        // assigning this variable to the head of the list
        var current = _head;

        // Loops through the list, if the current node has the value to be replace,
        // it creates a new node with the new value, it assigns the Next and Prev as it is
        // in the current Node, and checks if the current node is the Head or the Tail
        // by checking if the previous and next respectivily are null
        // If it is the head, it will assign the Prev of the next node to the new node
        // and continue the loop, since there is no previous node.
        // If the current node is the tail, it will assign the Next of the previous node
        // to the new node and return, since there is no next node to iterate through.
        // If the current node is in the middle, than it replaces it by assigning both
        // the Next of the previous node and the Prev of the next node to the new node
        while (current != null)
        {
            if (current.Data == oldValue)
            {
                Node newNode = new Node(newValue);
                newNode.Prev = current.Prev;
                newNode.Next = current.Next;
                if (current.Prev == null)
                {
                    current.Next!.Prev = newNode;
                    continue;
                }
                else if (current.Next == null)
                {
                    current.Prev!.Next = newNode;
                    return;
                }
                else
                {
                    current.Next!.Prev = newNode;
                    current.Prev!.Next = newNode;
                }
            }
            
            current = current.Next;
        }
        return;
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        var curr = _tail; // Start at the end since this is a backward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Prev; // Go backwards in the linked list
        }
        
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}