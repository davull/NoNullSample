namespace DefaultNullHandling.Domain;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }

    public override string ToString() =>
        $"{nameof(Street)}: {Street}, {nameof(City)}: {City}, {nameof(Zip)}: {Zip}, {nameof(Country)}: {Country}";
}