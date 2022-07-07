using SharedKernel.Functional;

namespace Domain.Customers;

public class Address
{
    public Option<string> Contact { get; init; }
    public string Line1 { get; }
    public Option<string> Line2 { get; init; }
    public string PostalCode { get; }
    public string City { get; }
    public Option<string> CountryCode { get; init; }

    public Address(string line1, string postalCode, string city)
    {
        Line1 = line1;
        PostalCode = postalCode;
        City = city;
    }

    public override string ToString()
    {
        return $"{nameof(Contact)}: {Contact}, {nameof(Line1)}: {Line1}, {nameof(Line2)}: {Line2}, " +
               $"{nameof(PostalCode)}: {PostalCode}, {nameof(City)}: {City}, {nameof(CountryCode)}: {CountryCode}";
    }
}