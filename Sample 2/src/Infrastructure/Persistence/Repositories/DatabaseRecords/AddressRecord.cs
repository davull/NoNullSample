namespace Infrastructure.Persistence.Repositories.DatabaseRecords;

internal record AddressRecord(
    Guid Id,
    Guid CustomerId,
    string? Contact,
    string Line1,
    string? Line2,
    string PostalCode,
    string City,
    string? CountryCode);