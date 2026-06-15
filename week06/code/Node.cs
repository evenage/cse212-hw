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
        // TODO Start Problem 1

        // Check for duplicate first
        if (value == Data)
        {
            return; // Already exists, do nothing
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
        // TODO Start Problem 2
         // Base case 1: We found it
    if (value == Data)
    {
        return true;
    }
    
    // Base case 2: Value is smaller, go left
    if (value < Data)
    {
        // If no left child, it's not in this tree
        if (Left is null)
            return false;
        // Otherwise keep searching left
        return Left.Contains(value);
    }
    // Base case 3: Value is bigger, go right
    else // value > Data
    {
        // If no right child, it's not in this tree  
        if (Right is null)
            return false;
        // Otherwise keep searching right
        return Right.Contains(value);
    }
      
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = 0;
    if (Left != null)
    {
        leftHeight = Left.GetHeight(); // recurse left
    }

    int rightHeight = 0;
    if (Right != null)
    {
        rightHeight = Right.GetHeight(); // recurse right
    }

    return 1 + Math.Max(leftHeight, rightHeight);
}
        //return 0; // Replace this line with the correct return statement(s)
    }
