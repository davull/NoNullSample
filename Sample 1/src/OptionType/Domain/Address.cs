using OptionType.Monads;
using static OptionType.Monads.F;

namespace OptionType.Domain;

public class Address
{
    public string Street { get; }
    public string City { get; }
    public Option<string> Zip { get; init; } = None;
    public Option<string> Country { get; init; } = None;

    public Address(string street, string city)
    {
        Street = street;
        City = city;
    }

    public override string ToString() =>
        $"{nameof(Street)}: {Street}, {nameof(City)}: {City}, {nameof(Zip)}: {Zip}, {nameof(Country)}: {Country}";
}