namespace DefaultNullHandling.Controllers;

public class CustomerDto
{
    public string Number { get; set; }
    public string FullName { get; set; }
    public string FormattedAddress { get; set; }

    public override string ToString() => 
        $"{nameof(Number)}: {Number}, {nameof(FullName)}: {FullName}, {nameof(FormattedAddress)}: {FormattedAddress}";
}