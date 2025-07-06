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

        // iterate through length and for eact index of length, multiply with number.

        // make an empty list
        double [] res = new double[length];
        // iterate through length
        for (int i = 0; i < length; ++i)
        {   
            // multiply number by current index and append the result to 'res'
            res[i] = number * (i+1);
        }

        return res;
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
        // Use modulo to handle cases where amount > data.Count
        amount = amount % data.Count;
        // Get the last 'amount' elements that need to move to the front
        List<int> lastpart = data.GetRange(data.Count - amount, amount);
        // get the first 'amount' elements stays after the rotated list
        List<int> firstpart = data.GetRange(0, data.Count - amount);

        // clear the current data list
        data.Clear();
        
        // Add the rotated last part to the now-empty data list
        data.AddRange(lastpart);
        // then add first part after it 
        data.AddRange(firstpart);
    }
}
