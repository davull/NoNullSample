using System.Text;
using OptionType.Domain;
using OptionType.Monads;
using static OptionType.Monads.F;

namespace OptionType.Controllers;

internal static class CustomerDtoFactory
{
    public static CustomerDto Create(Customer customer)
    {
        var formattedAddressOption = GetFormattedAddress(customer.Address);

        return new CustomerDto(
            number: customer.Number,
            fullName: $"{customer.FirstName.GetOrElse(string.Empty)} {customer.LastName}".Trim())
        {
            FormattedAddress = formattedAddressOption
                .GetOrElse(string.Empty)
        };
    }

    private static Option<string> GetFormattedAddress(Option<Address> address) =>
        address.Match(
            None: () => (Option<string>)None,
            Some: addr => GetFormattedAddress(addr));

    private static string GetFormattedAddress(Address address)
    {
        var sb = new StringBuilder();

        sb.AppendLine(address.Street);

        address.Zip
            .Map(zip => $"{zip} {address.City}")
            .Map(sb.AppendLine);

        address.Country
            .Map(sb.AppendLine);

        return sb.ToString();
    }
}