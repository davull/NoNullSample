namespace WebApp.Controllers.Dto;

public class CreateCustomerDto
{
    public string? FirstName { get; set; }
    public string LastName { get; set; }
    public string CustomerNo { get; set; }

    public override string ToString()
    {
        return $"{nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(CustomerNo)}: {CustomerNo}";
    }
}