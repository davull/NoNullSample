using OptionType.Monads;
using static OptionType.Monads.F;

namespace OptionType.Domain;

public class Customer
{
    public int Id { get; }
    public string Number { get; }
    public Option<string> FirstName { get; init; } = None;
    public string LastName { get; }
    public Option<Address> Address { get; init; } = None;

    public Customer(int id, string number, string lastName)
    {
        Id = id;
        Number = number;
        LastName = lastName;
    }

    public override string ToString() =>
        $"{nameof(Number)}: {Number}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}";
}