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

        //1. Create an array of doubles with the size of 'length'. this aaay will hold all the multiples of the number
        //2. Loop from i=0 to length -1. Each loop iteration fills one slot in the array.
        //3. For each i, calculate the multiple of the number by multiplying the number by (i + 1). This is because we want to start with the number itself (which is the first multiple), then 2 times the number, and so on.
        //- i=0 gives 1st multiple: number * (0 + 1) = number * 1 = number
        //- i=1 gives 2nd multiple: number * (1 + 1) = number * 2
        //- i=2 gives 3rd multiple: number * (2 + 1) = number * 3
        //- etc.
        //4. Store the calculated multiple in the array at index i.
        //5. After the loop finishes, return the filled array.

        //step 1: Create an array of doubles with the size of 'length'. this aaay will hold all the multiples of the number
        double[] result = new double[length];

        //step 2 & 3: loop and calculate multiples
        for (int i = 0; i < length; i++)
        { 
            //step 3: i+1 make sure we start with 1x, 2x, 3x,... not 0x,
            result[i] = number * (i + 1);
        }

        return result; // replace this return statement with your own
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
        //1. use modulo (%) to handle  cases where amount > data count
        //Example: rotatinga list of 9 items by 12 is the same as rotating it by 3 (12 % 9 = 3)
        //2. split the list into two parts: the last 'amount' elements. These will move to the front
        //-rightPart = the last 'amount' elements at the front.
        //-leftPart = the remaining elements at the front.
        //3. clear the original list so we can rebuild it.
        //4. add rightPart first, then leftPart using AddRange.
        //This puts the last elements at the front, achieving a right rotation.
        
        //step 1: use modulo to handle cases where amount > data count
        amount = amount % data.Count;

        //step 2: get the last 'amount' elements
        //start index = data.Count - amount, count = amount
        List<int> rightPart = data.GetRange(data.Count - amount, amount);

        //step 3: get the first part of the list (the remaining elements)
        //start index = 0, count = data.Count - amount
        List<int> leftPart = data.GetRange(0, data.Count - amount);

        //step 4: clear the original list
        data.Clear();

        //step5: rebuild the list with right part first, then left part
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
