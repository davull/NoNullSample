namespace NullableReferenceTypes.Domain;

public class Customer
{
    public int Id { get; }
    public string Number { get; }
    public string? FirstName { get; init; }
    public string LastName { get; }
    public Address? Address { get; init; }

    public Customer(int id, string number, string lastName)
    {
        Id = id;
        Number = number;
        LastName = lastName;
    }

    public override string ToString() =>
        $"{nameof(Number)}: {Number}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}";
}