using FluentAssertions;
using IdentityService.Domain.Models;

namespace IdentityService.Domain.Tests.Domain.Models;

public class RoleTests
{
    [Fact]
    public void Constructor_ShouldTrimNameAndDescription()
    {
        var role = new Role("  Admin  ", "  System administrator  ");

        role.Name.Should().Be("Admin");
        role.HasPermission("any").Should().BeFalse();
    }

    [Fact]
    public void AddPermission_ShouldAddUniquePermission()
    {
        var role = new Role("Admin");

        role.AddPermission("READ_USERS");
        role.AddPermission("READ_USERS"); // duplicate ignored
        role.AddPermission("WRITE_USERS");

        role.Permissions.Should().Contain(new[] { "READ_USERS", "WRITE_USERS" });
    }

    [Fact]
    public void RemovePermission_ShouldRemoveExistingPermission()
    {
        var role = new Role("Admin");
        role.AddPermission("READ_USERS");

        role.RemovePermission("READ_USERS");

        role.HasPermission("READ_USERS").Should().BeFalse();
    }
}

