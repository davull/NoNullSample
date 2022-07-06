namespace EmptyObjects.Domain;

public class Customer
{
    public static readonly Customer Empty = new Customer(
        id: 0,
        number: string.Empty,
        lastName: string.Empty);

    public int Id { get; }
    public string Number { get; }
    public string? FirstName { get; init; }
    public string LastName { get; }
    public Address Address { get; init; } = Address.Empty;

    public Customer(int id, string number, string lastName)
    {
        Id = id;
        Number = number;
        LastName = lastName;
    }

    public override string ToString() =>
        $"{nameof(Number)}: {Number}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}";
}