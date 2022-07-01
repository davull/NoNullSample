namespace DefaultNullHandling.Domain;

public class Customer
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }

    public override string ToString() =>
        $"{nameof(Number)}: {Number}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}";
}