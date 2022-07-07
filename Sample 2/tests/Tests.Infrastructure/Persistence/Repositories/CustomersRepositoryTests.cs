using Domain.Customers;
using FluentAssertions;
using Infrastructure.Persistence.Repositories;
using Xunit;
using Unit = System.ValueTuple;
using static SharedKernel.Functional.F;

namespace Tests.Infrastructure.Persistence.Repositories;

public class CustomersRepositoryTests
{
    [Fact]
    public void Get_withExistingId_returnsSome()
    {
        // Arrange
        var id = new Guid("8f34bcc7-100e-463b-9a9a-25f552f3457c");

        // Act
        var sut = new CustomersRepository();
        var customer = sut.Get(id);

        // Assert
        customer.Match<Unit>(
            Some: c => c.Id.Should().Be(id),
            None: () => Assert.True(false));
    }

    [Fact]
    public void Get_woExistingId_returnsNone()
    {
        // Arrange
        var id = Guid.Empty;

        // Act
        var sut = new CustomersRepository();
        var customer = sut.Get(id);

        // Assert
        customer.Match<Unit>(
            Some: _ => Assert.True(false),
            None: () => Assert.True(true));
    }

    [Fact]
    public void Add_addCustomer()
    {
        // Arrange
        var newCustomer = new Customer(
            id: Guid.NewGuid(),
            customerNumber: "T-001",
            firstName: None,
            lastName: "Schmitz");
        newCustomer.AddAddress(new Address(
            line1: "Hauptstrasse 111",
            postalCode: "95100",
            city: "Hamburg"));

        // Act
        var sut = new CustomersRepository();
        sut.Add(newCustomer);

        // Assert
        var addedCustomer = sut.Get(id: newCustomer.Id);
        addedCustomer.Match<Unit>(
            Some: _ => Assert.True(true),
            None: () => Assert.True(false));
    }
}