﻿namespace NullableReferenceTypes.Controllers;

public class CustomerDto
{
    public string Number { get; }
    public string FullName { get; }
    public string? FormattedAddress { get; set; }

    public CustomerDto(string number, string fullName)
    {
        Number = number;
        FullName = fullName;
    }

    public override string ToString() =>
        $"{nameof(Number)}: {Number}, {nameof(FullName)}: {FullName}, {nameof(FormattedAddress)}: {FormattedAddress}";
}