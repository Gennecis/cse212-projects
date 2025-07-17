using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: add 3 items tank, can, and co2 with priority 4, 1 and 5 respectively
    // Expected Result: item co2 with the priority 5 should be removed from the queue
    // Defect(s) Found: dequeue method skipped the last item in the queue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("tank", 4);
        priorityQueue.Enqueue("can", 1);
        priorityQueue.Enqueue("co2", 5);

        var res = priorityQueue.Dequeue();
        Assert.AreEqual("co2", res);
    }

    [TestMethod]
    // Scenario: add to the queue Musk, Putin, Bezos, and Trump with priority 4 for each of them.
    // Expected Result: Musk should be removed from the list first based on FIFO rule.
    // Defect(s) Found: the last item in the queue 'Trump' was removed instead of the one closest to the front of the queue.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Musk", 4);
        priorityQueue.Enqueue("Putin", 4);
        priorityQueue.Enqueue("Bezos", 4);
        priorityQueue.Enqueue("Trump", 4);

        var res = priorityQueue.Dequeue();
        Assert.AreEqual("Musk", res);
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: empty queue
    // Expected Result: I should get an error message indicating that the queue is empty.
    // Defect(s) Found: None.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    
    }
}