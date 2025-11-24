using FluentAssertions;
using IdentityService.Domain.Models;
using IdentityService.Domain.Tests.TestUtilities;
using IdentityService.Domain.ValueObjects;

namespace IdentityService.Domain.Tests.Domain.Models;

public class UserTests
{
    private readonly FakePasswordHasher _hasher = new("USER");

    [Fact]
    public void Constructor_WithValidData_ShouldInitializeProperties()
    {
        var email = Email.Create("user@example.com");
        var password = Password.Create("Password123!", _hasher);

        var user = new User("John Doe", email, password);

        user.Name.Should().Be("John Doe");
        user.Email.Should().Be(email);
        user.Password.Should().Be(password);
        user.EmailVerified.Should().BeFalse();
        user.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        user.UpdatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        user.UserRoles.Should().BeEmpty();
        user.RefreshTokens.Should().BeEmpty();
        user.Addresses.Should().BeEmpty();
    }

    [Fact]
    public void UpdateName_ShouldTrimAndSetName()
    {
        var user = CreateUser();

        user.UpdateName("   Jane Doe   ");

        user.Name.Should().Be("Jane Doe");
    }

    [Fact]
    public void UpdateEmail_ShouldSetEmailAndResetVerification()
    {
        var user = CreateUser();
        user.VerifyEmail();

        var newEmail = Email.Create("new@example.com");
        user.UpdateEmail(newEmail);

        user.Email.Should().Be(newEmail);
        user.EmailVerified.Should().BeFalse();
    }

    [Fact]
    public void ChangePassword_ShouldUpdatePassword()
    {
        var user = CreateUser();
        var newPassword = Password.Create("NewPassword123!", _hasher);

        user.ChangePassword(newPassword);

        user.Password.Should().Be(newPassword);
    }

    private User CreateUser()
    {
        var email = Email.Create("user@example.com");
        var password = Password.Create("Password123!", _hasher);
        return new User("John Doe", email, password);
    }
}

