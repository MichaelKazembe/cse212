/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Test 1: Create queue with valid size, add customers until full
        Console.WriteLine("Test 1: Add customers until full");
        var cs1 = new CustomerService(2);
        cs1.AddNewCustomerTest("Alice", "A1", "Password reset");
        cs1.AddNewCustomerTest("Bob", "B2", "Cannot login");
        cs1.AddNewCustomerTest("Charlie", "C3", "Account locked"); // Should show error
        Console.WriteLine(cs1);
        Console.WriteLine("=================");

        // Test 2: Create queue with invalid size, should default to 10
        Console.WriteLine("Test 2: Invalid size defaults to 10");
        var cs2 = new CustomerService(0);
        for (int i = 0; i < 11; i++)
            cs2.AddNewCustomerTest($"User{i}", $"ID{i}", "Test"); // 11th should show error
        Console.WriteLine(cs2);
        Console.WriteLine("=================");

        // Test 3: Serve customers until empty
        Console.WriteLine("Test 3: Serve customers until empty");
        var cs3 = new CustomerService(2);
        cs3.AddNewCustomerTest("Dave", "D4", "Forgot password");
        cs3.AddNewCustomerTest("Eve", "E5", "Billing issue");
        cs3.ServeCustomerTest(); // Should serve Dave
        cs3.ServeCustomerTest(); // Should serve Eve
        cs3.ServeCustomerTest(); // Should show error (empty)
        Console.WriteLine(cs3);
        Console.WriteLine("=================");
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
    // Test helper for AddNewCustomer (bypasses Console input)
    public void AddNewCustomerTest(string name, string accountId, string problem) {
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    // Test helper for ServeCustomer (bypasses Console input)
    public void ServeCustomerTest() {
        if (_queue.Count == 0) {
            Console.WriteLine("No customers in queue.");
            return;
        }
        var customer = _queue[0];
        Console.WriteLine($"Serving: {customer}");
        _queue.RemoveAt(0);
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