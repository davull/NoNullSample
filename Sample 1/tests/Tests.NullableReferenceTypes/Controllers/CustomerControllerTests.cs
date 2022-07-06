using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NullableReferenceTypes.Controllers;
using Snapshooter.Xunit;
using Xunit;

namespace Tests.NullableReferenceTypes.Controllers;

public class CustomerControllerTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GetExistingCustomer(int customerId)
    {
        // Arrange
        var sut = new CustomerController();

        // Act
        var customer = sut.Get(customerId);

        // Assert
        customer.Should().BeOfType<OkObjectResult>();

        customer
            .Should()
            .MatchSnapshot(
                snapshotName: $"{nameof(CustomerControllerTests)}.{nameof(GetExistingCustomer)}.{customerId}");
    }

    [Fact]
    public void GetNonExistingCustomer()
    {
        // Arrange
        var sut = new CustomerController();

        // Act
        var customer = sut.Get(99);

        // Assert
        customer.Should().BeOfType<NotFoundResult>();
    }
}