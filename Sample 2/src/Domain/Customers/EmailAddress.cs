namespace Domain.Customers;

public class EmailAddress
{
    public static EmailAddress Empty = new EmailAddress(string.Empty, false);
    
    public string Address { get; }
    public bool IsValid { get; }

    private EmailAddress(string address, bool isValid)
    {
        Address = address;
        IsValid = isValid;
    }

    public static EmailAddress Parse(string address)
    {
        // Do some Regex validation here...

        return new EmailAddress(address, true);
    }

    public override string ToString()
    {
        return $"{nameof(Address)}: {Address}, {nameof(IsValid)}: {IsValid}";
    }
}