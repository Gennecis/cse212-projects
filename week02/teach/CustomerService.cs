/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: specify the maximum size of the Customer Service Queue as 0.
        // Expected Result: the size should default to 10.
        // Console.WriteLine("Test 1");
        var cs = new CustomerService(0);
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // Console.WriteLine($"Before Serving Customers: {cs}");
        // Console.WriteLine("=================");
        // cs.AddNewCustomer();
        // Console.WriteLine($"After Serving Customers: {cs}");

        // Defect(s) Found: None.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: specify the maximum size of the Customer Service Queue as 15.
        // Expected Result: we should get an error when we try to add a 16th customer to the queue.

        // Console.WriteLine("Test 2");
        // cs = new CustomerService(15);
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // Console.WriteLine($"Before Serving Customers: {cs}");
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // Console.WriteLine($"After Serving Customers: {cs}");

        // Defect(s) Found: max_size increased as the queue increased. Should have output an error after 15 entries.

        Console.WriteLine("=================");
        // Test 3
        // Scenario: remove the next customer from the queue and display the details.
        // Expected Result: the first customer should be removed and displayed.
        // Console.WriteLine("Test 3");
        // cs = new CustomerService(4);
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.AddNewCustomer();
        // cs.ServeCustomer();


        Console.WriteLine("=================");
        // Test 4
        // Scenario: attempt to serve customer when the queue is empty
        // Expected Result: I should get an error indicating that the queue is empty
        Console.WriteLine("Test 4");
        cs = new CustomerService(4);
        cs.ServeCustomer();
        // Defect(s) found: the program crashed, I should have gotten an error message instead.
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) // fix defect from test 2
        {
            Console.WriteLine("Maximum Number of Customers in Queue."); 
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count > 0)
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
        else
        {
            Console.WriteLine("queue is empty"); // fix defect from test 4
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}