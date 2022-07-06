using NullableReferenceTypes.Domain;

namespace NullableReferenceTypes.Repositories;

public class CustomerRepository
{
    private static readonly IList<Customer> _customers;

    static CustomerRepository()
    {
        _customers = new List<Customer>
        {
            // Fully populated customer
            new(id: 1, number: "001", lastName: "Smith")
            {
                FirstName = "John",
                Address = new(street: "123 Main St", city: "Anytown")
                {
                    Country = "USA",
                    Zip = "12345"
                }
            },

            // Customer with some null fields
            new(id: 2, number: "002", lastName: null!)
            {
                Address = new(street: "456 Main St", city: null!)
                {
                    Country = "USA",
                },
            },

            // Customer w/o address
            new(id: 3, number: "003", lastName: "Marley")
            {
                FirstName = "Bob",
            },
        };
    }

    public Customer? GetCustomer(int id) => _customers.FirstOrDefault(c => c.Id == id);
}