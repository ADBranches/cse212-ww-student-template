using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2 - Test cases were written from the PriorityQueue requirements.
// Requirements covered:
// 1. Enqueue adds items to the back of the queue.
// 2. Dequeue returns and removes the item with the highest priority.
// 3. If multiple items have the same highest priority, the earliest/front-most item is removed first.
// 4. Dequeue on an empty queue throws InvalidOperationException with message "The queue is empty.".

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items where the last item has the highest priority.
    // Expected Result: The highest-priority item is returned first, then the next highest, then the lowest.
    // Defect(s) Found: Initial defective code did not inspect the final queue item and did not remove dequeued items.
    public void TestPriorityQueue_HighestPriorityIncludingLastItem()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority.
    // Expected Result: Items with equal priority are dequeued in FIFO order.
    // Defect(s) Found: Initial defective code used >= and selected the later equal-priority item instead of the first one.
    public void TestPriorityQueue_SamePriorityUsesFifoOrder()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 4);
        priorityQueue.Enqueue("Second", 4);
        priorityQueue.Enqueue("Lower", 2);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Lower", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty priority queue.
    // Expected Result: InvalidOperationException is thrown with message "The queue is empty.".
    // Defect(s) Found: No defect found in the exception type/message behavior during baseline review.
    public void TestPriorityQueue_EmptyQueueThrowsExpectedException()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }
}
