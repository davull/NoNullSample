using System.Text;
using DefaultNullHandling.Domain;

namespace DefaultNullHandling.Controllers;

internal static class CustomerDtoFactory
{
    public static CustomerDto Create(Customer customer)
    {
        if (customer is null)
            throw new ArgumentNullException(nameof(customer));

        return new CustomerDto
        {
            Number = customer.Number ?? string.Empty,
            FullName = $"{customer.FirstName} {customer.LastName}".Trim(),
            FormattedAddress = GetFormattedAddress(customer.Address),
        };
    }

    private static string GetFormattedAddress(Address address)
    {
        if (address is null)
            return null;

        var sb = new StringBuilder();

        if (!string.IsNullOrEmpty(address.Street))
            sb.AppendLine(address.Street);

        if (!string.IsNullOrEmpty(address.Zip) &&
            !string.IsNullOrEmpty(address.City))
            sb.AppendLine($"{address.Zip} {address.City}");

        if (!string.IsNullOrEmpty(address.Country))
            sb.AppendLine(address.Country);

        return sb.ToString();
    }
}