namespace Infrastructure.Persistence.Repositories.DatabaseRecords;

internal record CustomerRecord(
    Guid Id,
    string Number,
    string FirstName,
    string LastName,
    string Email,
    string? Phone);
