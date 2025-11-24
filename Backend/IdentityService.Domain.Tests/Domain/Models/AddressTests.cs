using FluentAssertions;
using IdentityService.Domain.Models;

namespace IdentityService.Domain.Tests.Domain.Models;

public class AddressTests
{
    [Fact]
    public void Constructor_WithOptionalFields_ShouldStoreValues()
    {
        var userId = Guid.NewGuid();
        var address = new Address(
            userId,
            "Main Street",
            "10B",
            "Metropolis",
            "12345",
            "USA",
            apartmentNumber: "12",
            floor: 3,
            entrance: "B",
            isDefault: true);

        address.UserId.Should().Be(userId);
        address.Street.Should().Be("Main Street");
        address.HouseNumber.Should().Be("10B");
        address.ApartmentNumber.Should().Be("12");
        address.Floor.Should().Be(3);
        address.Entrance.Should().Be("B");
        address.IsDefault.Should().BeTrue();
    }

    [Fact]
    public void Update_ShouldReplaceValues()
    {
        var address = CreateAddress();

        address.Update(
            street: "Second Ave",
            houseNumber: "5",
            city: "Gotham",
            postalCode: "54321",
            country: "USA",
            apartmentNumber: null,
            floor: null,
            entrance: "1");

        address.Street.Should().Be("Second Ave");
        address.HouseNumber.Should().Be("5");
        address.ApartmentNumber.Should().BeNull();
        address.Floor.Should().BeNull();
        address.Entrance.Should().Be("1");
    }

    [Fact]
    public void SetAsDefault_ShouldMarkAddressAsDefault()
    {
        var address = CreateAddress();

        address.SetAsDefault();

        address.IsDefault.Should().BeTrue();
    }

    [Fact]
    public void RemoveDefault_ShouldUnmarkDefaultFlag()
    {
        var address = CreateAddress();
        address.SetAsDefault();

        address.RemoveDefault();

        address.IsDefault.Should().BeFalse();
    }

    private static Address CreateAddress()
    {
        return new Address(
            Guid.NewGuid(),
            "Main Street",
            "10A",
            "Metropolis",
            "12345",
            "USA");
    }
}

