using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items come out in descending priority order
    // Defect(s) Found: None if implementation is correct
    public void Dequeue_RemovesHighestPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Two items have the same highest priority
    // Expected Result: The one added first should be dequeued first - FIFO for ties
    // Defect(s) Found: None if FIFO is implemented correctly
    public void Dequeue_UsesFIFOForSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 3);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue always adds to the back regardless of priority
    // Expected Result: Order only changes on Dequeue, not on Enqueue
    // Defect(s) Found: None if Enqueue is simple append
    public void Enqueue_AddsToBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);

        // B has higher priority, so it comes out first even though A was added first
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue called on empty queue
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None if exception is thrown correctly
    public void Dequeue_EmptyQueueThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities with multiple items at same priority
    // Expected Result: Order should be B(5), D(5), A(2), C(2), E(1)
    // Defect(s) Found: None if both priority and FIFO rules work together
    public void MixedPriorities_MaintainsCorrectOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 5);
        priorityQueue.Enqueue("E", 1);

        Assert.AreEqual("B", priorityQueue.Dequeue()); // 5, added earlier
        Assert.AreEqual("D", priorityQueue.Dequeue()); // 5, added later
        Assert.AreEqual("A", priorityQueue.Dequeue()); // 2, added earlier
        Assert.AreEqual("C", priorityQueue.Dequeue()); // 2, added later
        Assert.AreEqual("E", priorityQueue.Dequeue()); // 1
    }

    [TestMethod]
    // Scenario: Dequeue removes the item so Count decreases
    // Expected Result: Item is actually removed from queue
    // Defect(s) Found: None if RemoveAt is called in Dequeue
    public void Dequeue_RemovesItemFromQueue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);

        priorityQueue.Dequeue();

        Assert.AreEqual("A", priorityQueue.Dequeue());
    }
}