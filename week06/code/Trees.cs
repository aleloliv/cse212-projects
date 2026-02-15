public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.  If the values in the
    /// sortedNumbers were inserted in order from left to right into the BST, then it
    /// would resemble a linked list (unbalanced). To get a balanced BST, the
    /// InsertMiddle function is called to find the middle item in the list to add
    /// first to the BST. The InsertMiddle function takes the whole list but also takes
    /// a range (first to last) to consider.  For the first call, the full range of 0 to
    /// Length-1 used.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// This function will attempt to insert the item in the middle of 'sortedNumbers' into
    /// the 'bst' tree. The middle is determined by using indices represented by 'first' and
    /// 'last'.
    /// For example, if the function was called on:
    ///
    /// sortedNumbers = new[]{10, 20, 30, 40, 50, 60};
    /// first = 0;
    /// last = 5;
    /// 
    /// then the value 30 (index 2 which is the middle) would be added 
    /// to the 'bst' (the insert function in the <see cref="BinarySearchTree"/> can be used
    /// to do this).   
    ///
    /// Subsequent recursive calls are made to insert the middle from the values 
    /// before 30 and the values after 30.  If done correctly, the order
    /// in which values are added (which results in a balanced bst) will be:
    /// 
    /// 30, 10, 20, 50, 40, 60
    /// 
    /// This function is intended to be called the first time by CreateTreeFromSortedList.
    ///
    /// The purpose for having the first and last parameters is so that we do 
    /// not need to create new sub-lists when we make recursive calls.  Avoid 
    /// using list slicing to create sub-lists to solve this problem.    
    /// </summary>
    /// <param name="sortedNumbers">input numbers that are already sorted</param>
    /// <param name="first">the first index in the sortedNumbers to insert</param>
    /// <param name="last">the last index in the sortedNumbers to insert</param>
    /// <param name="bst">the BinarySearchTree in which to insert the values</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: if the first number is greater than the last, stop the recursion, 
        // in other words if the index of the first number is greater than the last, it stops the function
        // This will only happen if the list cannot be divided any further, 
        // and the funcion recieved the same index numbers as paramathers, 
        // since the recursive call is subtracting 1 from the last number, 
        // than this will only be true if there is no more numbers to be added to the tree
        if (first > last)
        {
            return;
        }
        // Calculates the middle of the list by adding both numbers and dividing by 2, for example, list = [1, 2, 3, 4, 5],
        // The first number is 0 and the last is 4, 0 + 4 = 4, 4 / 2 = 2
        int middle = (first + last) / 2;

        // Insert the value in the middle of the list, in the example list would be 3 wich is index 2
        bst.Insert(sortedNumbers[middle]);

        // Calls the function recursively to add to the right and to the left,
        // This works dividing the list into smaller lists using the index middle,
        // For the left it would call (using the example) [1, 2], index 0 and 2 - 1 = 1
        // For the right it would call [4, 5] index 2 + 1 = 3 and 4
        // Than for the left it would call [1] index 0 and 1 - 1 = 0
        // For the right [2] index 1 and 2 - 1 = 1
        // Than again for the left it would call [] because it would be 0 and 0 - 1 = -1 
        // or 1 and 1 - 1 = 0 wich stops the function 
        InsertMiddle(sortedNumbers, first, middle - 1, bst);
        InsertMiddle(sortedNumbers, middle + 1, last, bst);
    }
}