using Infrastructure.Persistence.Repositories.DatabaseRecords;

namespace Infrastructure.Persistence.Repositories;

internal static class Database
{
    public static IList<CustomerRecord> Customers { get; }
    public static IList<AddressRecord> Addresses { get; }

    static Database()
    {
        Customers = GetCustomers().ToList();
        Addresses = GetAddresses(Customers).ToList();
    }

    private static IEnumerable<CustomerRecord> GetCustomers()
    {
        const string notSetFirstName = "-";
        const string notSetEmail = "";

        yield return new CustomerRecord(
            Id: new Guid("d1183f2e-3eb4-46b4-9097-d2b382764273"),
            Number: "C-001",
            FirstName: "Max",
            LastName: "Mustermann",
            Email: "max.mustermann@test.de",
            Phone: "+49 1324 4568");
        yield return new CustomerRecord(
            Id: new Guid("8f34bcc7-100e-463b-9a9a-25f552f3457c"),
            Number: "C-002",
            FirstName: notSetFirstName,
            LastName: "Schmitz",
            Email: notSetEmail,
            Phone: "+49 1324 4568");
        yield return new CustomerRecord(
            Id: new Guid("a9a6bb16-c1b5-4b71-ad43-81490d504b42"),
            Number: "C-003",
            FirstName: "Peter",
            LastName: "Pan",
            Email: "peter.pan@test.de",
            Phone: null);
    }

    private static IEnumerable<AddressRecord> GetAddresses(
        IEnumerable<CustomerRecord> customerRecords)
    {
        foreach (var customerRecord in customerRecords)
        {
            yield return new AddressRecord(
                Id: Guid.NewGuid(),
                CustomerId: customerRecord.Id,
                Contact: "Niko Laus",
                Line1: "Mainstreet 1",
                Line2: "p/o Box 1",
                PostalCode: "12345",
                City: "New York",
                CountryCode: "US");

            yield return new AddressRecord(
                Id: Guid.NewGuid(),
                CustomerId: customerRecord.Id,
                Contact: null,
                Line1: "Wallstreet 77",
                Line2: null,
                PostalCode: "9999",
                City: "New York",
                CountryCode: null);
        }
    }
}