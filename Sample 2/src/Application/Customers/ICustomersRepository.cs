using Domain.Customers;
using SharedKernel.Functional;

namespace Application.Customers;

public interface ICustomersRepository
{
    Option<Customer> Get(Guid id);

    IReadOnlyCollection<Customer> GetAll();

    void Add(Customer customer);
    
    void Update(Customer customer);
}