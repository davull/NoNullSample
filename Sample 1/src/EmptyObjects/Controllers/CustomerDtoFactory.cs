using System.Text;
using EmptyObjects.Domain;

namespace EmptyObjects.Controllers;

internal static class CustomerDtoFactory
{
    public static CustomerDto Create(Customer customer)
    {
        if (customer is null)
            throw new ArgumentNullException(nameof(customer));

        return new CustomerDto(
            number: customer.Number,
            fullName: $"{customer.FirstName} {customer.LastName}".Trim())
        {
            FormattedAddress = GetFormattedAddress(customer.Address),
        };
    }

    private static string GetFormattedAddress(Address address)
    {
        if (address == Address.Empty)
            return string.Empty;

        var sb = new StringBuilder();

        sb.AppendLine(address.Street);

        if (!string.IsNullOrEmpty(address.Zip))
            sb.AppendLine($"{address.Zip} {address.City}");

        if (!string.IsNullOrEmpty(address.Country))
            sb.AppendLine(address.Country);

        return sb.ToString();
    }
}