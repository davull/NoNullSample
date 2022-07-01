using OptionType.Domain;
using OptionType.Monads;

using static OptionType.Monads.F;

namespace OptionType.Repositories;

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
                Address = new Address(street: "123 Main St", city: "Anytown")
                {
                    Country = "USA",
                    Zip = "12345",
                }
            },

            // Customer with some null fields
            new(id: 2, number: "002", lastName: null!)
            {
                Address = new Address(street: "456 Main St", city: "New York")
                {
                    Country = "USA",
                    Zip = None,
                },
            },

            // Customer w/o address
            new(id: 3, number: "003", lastName: "Marley")
            {
                FirstName = "Bob",
            },
        };
    }

    public Option<Customer> GetCustomer(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        return customer is not null
            ? Some(customer)
            : None;
    }
}