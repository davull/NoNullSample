using System.Collections.Immutable;
using Application.Customers;
using Domain.Customers;
using Infrastructure.Persistence.Repositories.DatabaseRecords;
using SharedKernel;
using SharedKernel.Functional;
using static SharedKernel.Functional.F;

namespace Infrastructure.Persistence.Repositories;

public class CustomersRepository : ICustomersRepository
{
    public Option<Customer> Get(Guid id)
    {
        var customerRecord = Database.Customers
            .SingleOrDefault(c => c.Id == id);
        var addressRecords = customerRecord is not null
            ? Database.Addresses.Where(a => a.CustomerId == customerRecord.Id)
            : Enumerable.Empty<AddressRecord>();

        var customer = customerRecord is not null
            ? Some(Map(customerRecord))
            : None;

        addressRecords
            .Select(Map)
            .Do(address =>
                customer.ForEach(
                    c => c.AddAddress(address)));

        return customer;
    }

    public IReadOnlyCollection<Customer> GetAll()
    {
        var customers = Database.Customers
            .Select(Map)
            .ToImmutableList();
        customers.Do(customer =>
            Database.Addresses
                .Where(address => address.CustomerId == customer.Id)
                .Select(Map)
                .Do(customer.AddAddress));

        return customers;
    }

    public void Add(Customer customer)
    {
        var customerRecord = Map(customer);
        Database.Customers.Add(customerRecord);

        var addressRecords = customer.Addresses
            .Select(addr => Map(customer.Id, addr));
        Database.Addresses.AddRange(addressRecords);
    }

    public void Update(Customer customer)
    {
        throw new NotImplementedException();
    }

    private static Customer Map(CustomerRecord record)
    {
        // "-" defines a not set value
        var firstName = !string.Equals(record.FirstName, "-")
            ? Some(record.FirstName)
            : None;
        var email = !string.IsNullOrEmpty(record.Email)
            ? Some(EmailAddress.Parse(record.Email))
            : None;

        var customer = new Customer(
            id: record.Id,
            customerNumber: record.Number,
            firstName: firstName,
            lastName: record.LastName);
        customer.SetContactDetails(
            emailAddress: email,
            phoneNumber: record.Phone!);

        return customer;
    }

    private static Address Map(AddressRecord record)
    {
        return new Address(
            line1: record.Line1,
            postalCode: record.PostalCode,
            city: record.City)
        {
            Contact = record.Contact!,
            Line2 = record.Line2!,
            CountryCode = record.CountryCode!
        };
    }

    private static CustomerRecord Map(Customer customer)
    {
        return new CustomerRecord(
            Id: customer.Id,
            Number: customer.CustomerNumber,
            FirstName: customer.FirstName.GetOrElse("-"),
            LastName: customer.LastName,
            Email: customer.EmailAddress
                .GetOrElse(EmailAddress.Empty)
                .Address,
            Phone: customer.PhoneNumber.GetOrElse((string?)null!));
    }

    private static AddressRecord Map(Guid customerId, Address address)
    {
        return new AddressRecord(
            Id: Guid.NewGuid(),
            CustomerId: customerId,
            Contact: address.Contact.GetOrElse((string?)null!),
            Line1: address.Line1,
            Line2: address.Line2.GetOrElse((string?)null!),
            PostalCode: address.PostalCode,
            City: address.City,
            CountryCode: address.CountryCode.GetOrElse("DE"));
    }
}