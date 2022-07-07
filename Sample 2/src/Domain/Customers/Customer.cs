using System.Collections.ObjectModel;
using SharedKernel.Functional;

namespace Domain.Customers;

public class Customer
{
    public Guid Id { get; }
    public string CustomerNumber { get; }
    public Option<string> FirstName { get; private set; }
    public string LastName { get; private set; }
    public Option<EmailAddress> EmailAddress { get; private set; }
    public Option<string> PhoneNumber { get; private set; }

    private readonly IList<Address> _addresses = new List<Address>();
    public IReadOnlyCollection<Address> Addresses => new ReadOnlyCollection<Address>(_addresses);

    public Customer(Guid id, string customerNumber, Option<string> firstName, string lastName)
    {
        Id = id;
        CustomerNumber = customerNumber;
        FirstName = firstName;
        LastName = lastName;
    }

    public void SetName(Option<string> firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public void SetContactDetails(Option<EmailAddress> emailAddress, Option<string> phoneNumber)
    {
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
    }

    public void AddAddress(Address address) => _addresses.Add(address);
    
    public void RemoveAddress(Address address) => _addresses.Remove(address);

    public override string ToString()
    {
        return $"{nameof(CustomerNumber)}: {CustomerNumber}, {nameof(FirstName)}: {FirstName}, " +
               $"{nameof(LastName)}: {LastName}";
    }
}