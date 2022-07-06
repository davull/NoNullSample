using DefaultNullHandling.Domain;

namespace DefaultNullHandling.Repositories;

public class CustomerRepository
{
    private static readonly IList<Customer> _customers;

    static CustomerRepository()
    {
        _customers = new List<Customer>
        {
            // Fully populated customer
            new()
            {
                Id = 1,
                Number = "001",
                FirstName = "John",
                LastName = "Smith",
                Address = new()
                {
                    Street = "123 Main St",
                    City = "Anytown",
                    Country = "USA",
                    Zip = "12345"
                }
            },

            // Customer with some null fields
            new()
            {
                Id = 2,
                Number = "002",
                FirstName = "Jane",
                LastName = null,
                Address = new()
                {
                    Street = "456 Main St",
                    City = null,
                    Country = "USA",
                    Zip = null,
                },
            },

            // Customer w/o address
            new()
            {
                Id = 3,
                Number = "003",
                FirstName = "Bob",
                LastName = "Marley",
                Address = null,
            },
        };
    }

    public Customer GetCustomer(int id) => _customers.FirstOrDefault(c => c.Id == id);
}