public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // -----------------------------------------------------------------------------------------------------------------
        // First create an empty array of type double and size using the variable length and a variable which value is 0. 
        // Then create a loop that will use a temporary int variable that will count
        // from 1 to the length and multiply the number variable by the temporary variable and add the result to the array,
        // the resulting array should be returned at the end.
        // ----------------------------------------------------------------------------------------------------------------
        double[] multiples = new double[length]; // Empty array with size of length
        double multiple = 0.0; // Variable which will hold the value to be added to the multiples[] array
        for (int i = 1; i <= length; i++) // the i variable will start from 1, because it will mutiply the number by it, so it can't be 0.
        {
            multiple = number * i;
            multiples[i-1] = multiple; // The i variable must be subtracted by 1, because the first position in the array is 0.
        }

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // -----------------------------------------------------------------------------------------------------------------
        // First, create a new temporary list that contains the values from the amount variable to the end of the original list, 
        // than remove the values from the original list, using a loop that repeats the amount of values that the temporary
        // list has, and removes always at index 0, using RemoveAt
        // lastly insert the values to the end of the original list using a loop to add all of the values from the
        // temporary list, using foreach and Add, thus manipulating the original list and returning nothing.
        // -----------------------------------------------------------------------------------------------------------------
        if (data.Count == 0) // This makes sure that the list is not empty.
        {
            return;
        }

        amount %= data.Count; // This is in case the amount value is greater than the list size.

        if (amount == 0) // This makes sure that the amount is not 0.
        {
            return;
        }
        
        var tempData = data.GetRange(0, data.Count - amount); // This is the temporary list that receives the values from the original list from the begining to the number of values - amount index.
        
        for (int i = 0; i < tempData.Count; i++) // Removes from the original list 
        {
            data.RemoveAt(0);
        }
        foreach (var number in tempData)
        {
            data.Add(number);
        }
    }
}
