using System;
using System.Collections.Generic;

public class SimpleQueue
{
    private readonly List<int> _queue = new();

    public void Enqueue(int value)
    {
        _queue.Add(value);
    }

    public int Dequeue()
    {
        if (_queue.Count <= 0)
            throw new InvalidOperationException("Queue is empty");

        var value = _queue[0];
        _queue.RemoveAt(0);
        return value;
    }
    public static void Run()
    {
       // int value;
        // Test Cases

        // Test 1
        // Scenario: Enqueue one value and then Dequeue it.
        // Expected Result: It should display 100
        Console.WriteLine("Test 1");
        var queue = new SimpleQueue();
        queue.Enqueue(100);
        var value = queue.Dequeue();
        Console.WriteLine(value);
        // Defect(s) Found: None

        Console.WriteLine("------------");

        // Test 2
        // Scenario: Enqueue multiple values and then Dequeue all of them
        // Expected Result: It should display 200, then 300, then 400 in that order
        Console.WriteLine("Test 2");
        queue = new SimpleQueue();
        queue.Enqueue(200);
        queue.Enqueue(300);
        queue.Enqueue(400);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);
        // Defect(s) Found: 

        Console.WriteLine("------------");

        // Test 3
        // Scenario: Dequeue from an empty Queue
        // Expected Result: An exception should be raised
        Console.WriteLine("Test 3");
        queue = new SimpleQueue();
        try
        {
            queue.Dequeue();
            Console.WriteLine("Oops ... This shouldn't have worked.");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("I got the exception as expected.");
        }
    }

    public List<int> Dequeue(int count)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive.");

        if (_queue.Count < count)
            throw new InvalidOperationException("Not enough items in the queue.");

        var values = _queue.GetRange(0, count);
        _queue.RemoveRange(0, count);
        return values;
    }
}