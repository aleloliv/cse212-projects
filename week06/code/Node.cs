using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value == Data) // If the value already exists in the tree, stop trying to insert.
        {
            return;
        }
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data) // If the value already exists in the tree, it has found that the tree contains the value.
        {
            return true;
        }

        else if (value < Data) // Search the left node if the current value is heigher than the value being searched.
        {
            Left?.Contains(value);
        }
        
        else
        {
            Right?.Contains(value); // Search the right node if the current value is lesser than the value being searched.
        }

        // If the entire tree was searched and the value was not found, the tree doesn't contain the value.
        return false;
    }

    public int GetHeight()
    {
        // Checks if the Left node is null, if it is, then the value of this variable is 0, if it isn't, 
        // than the value is the height of the left node.
        int leftHeight = (Left == null ? 0 : Left.GetHeight());

        // Checks if the Right node is null, if it is, then the value of this variable is 0, if it isn't, 
        // than the value is the height of the right node.
        int rightHeight = (Right == null ? 0 : Right.GetHeight());

        // The heigher is the node that contains more children
        int heigher = Math.Max(leftHeight, rightHeight);

        // Return 1 + the heigher node, this means that the original node counts as 1, 
        // if there are no more nodes, than 1 is the height of the tree, 
        // if there are more nodes, 
        // than the height of tree will be 1 (the original node) + the height of the heighest sub tree
        return 1 + heigher;
    }
}