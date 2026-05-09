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
        // PLAN:
        // 1. Create a new array of type double with a size equal to the value of 'length'.
        // 2. The first element of the array should be equal to the input value 'number'.
        // 3. Use a loop that runs from index 0 up to (length - 1).
        // 4. For each index i, calculate the value as number multiplied by (i + 1).
        //    - This works because the first multiple is number * 1, the second is number * 2, etc.
        // 5. Store each calculated multiple into the array at the corresponding index.
        // 6. After the loop finishes, return the filled array.
        //
        // This approach ensures the array contains consecutive multiples of the given number
        // and that the array size exactly matches the requested length.

        // Create the array with the required length
        double[] result = new double[length];

        // Fill the array with multiples of the given number
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
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
        // PLAN:
        // 1. Understand that rotating the list to the right means elements at the end of the list
        //    move to the front, while the relative order of all elements is preserved.
        //
        // 2. Determine how many positions to rotate by using the provided 'amount'.
        //    Since amount is guaranteed to be between 1 and data.Count, it can be used directly.
        //
        // 3. Identify the split point in the list by subtracting amount from data.Count.
        //    - The elements before this index will move to the end of the list.
        //    - The elements from this index to the end will move to the front.
        //
        // 4. Create a temporary list containing the last 'amount' elements
        //    using GetRange(splitIndex, amount).
        //
        // 5. Remove those elements from the original list using RemoveRange.
        //
        // 6. Insert the saved elements at the beginning of the list using InsertRange(0, tempList).
        //
        // 7. The original list 'data' is now rotated in place, so nothing is returned.

        int splitIndex = data.Count - amount;
        List<int> temp = data.GetRange(splitIndex, amount);
        data.RemoveRange(splitIndex, amount);
        data.InsertRange(0, temp);
    }
}
