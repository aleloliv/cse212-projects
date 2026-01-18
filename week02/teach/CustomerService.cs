/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Add 1 customer and serve this customer
        // Expected Result: Display the customer that was added, this found that the ServeCustomer should get the customer before deleting from the list.
        Console.WriteLine("Test 1");

        var service = new CustomerService(3);
        service.AddNewCustomer();
        service.ServeCustomer();

        // Defect(s) Found: The customer was being removed before it was served by ServeCustomer.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add two customers and serve them in the right order.
        // Expected Result: Display the customers in the same order that they were entered.
        Console.WriteLine("Test 2");

        var service1 = new CustomerService(3);
        service1.AddNewCustomer();
        service1.AddNewCustomer();
        service1.ServeCustomer();
        service1.ServeCustomer();

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Is the queue's size defaulted to 10 if an incorrect value is informed?
        // Expected Result: The queue's size is defaulted to 10.
        Console.WriteLine("Test 3");

        var service2 = new CustomerService(-1);
        Console.WriteLine(service2._maxSize);
        
        // Defect(s) Found: None

        // Test 4
        // Scenario: Trying to serve the customer before adding one.
        // Expected Result: An error message is displayed.
        Console.WriteLine("Test 4");

        var service3 = new CustomerService(3);
        service3.ServeCustomer();
        
        // Defect(s) Found: This showed that the size of the queue should be checked by ServeCustomer before atempting to serve any customer.

        // Test 5
        // Scenario: What happens if I try to add more customers than the line's size?
        // Expected Result: An error message should be displayed.
        Console.WriteLine("Test 5");

        var service4 = new CustomerService(3);
        service4.AddNewCustomer();
        service4.AddNewCustomer();
        service4.AddNewCustomer();
        service4.AddNewCustomer();
        Console.WriteLine($"Service line: {service4}");

        // Defect(s) Found: The AddNewCustomer method was checking if the total amount of elements in queue was only greater than the maximum capacity of the queue, instead of it being equal to or greater.
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
        if (_queue.Count >= _maxSize) {
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
        if (_queue.Count <= 0)
        {
            Console.WriteLine("No customer to be served");
        }
        else
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
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