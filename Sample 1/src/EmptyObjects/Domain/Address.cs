namespace EmptyObjects.Domain;

public class Address
{
    public static readonly Address Empty = new Address(
        street: string.Empty,
        city: string.Empty);
    
    public string Street { get; }
    public string City { get; }
    public string? Zip { get; init; }
    public string? Country { get; init; }

    public Address(string street, string city)
    {
        Street = street;
        City = city;
    }

    public override string ToString() =>
        $"{nameof(Street)}: {Street}, {nameof(City)}: {City}, {nameof(Zip)}: {Zip}, {nameof(Country)}: {Country}";
}