using FluentAssertions;
using IdentityService.Domain.Tests.TestUtilities;
using IdentityService.Domain.ValueObjects;

namespace IdentityService.Domain.Tests.Domain.ValueObjects;

public class PasswordTests
{
    private readonly FakePasswordHasher _hasher = new("TEST");

    [Fact]
    public void Create_WithValidPlainPassword_ShouldHashPassword()
    {
        var password = Password.Create("StrongPass1!", _hasher);

        password.Hash.Should().Be("TEST:StrongPass1!");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("short")]
    public void Create_WithInvalidPlainPassword_ShouldThrow(string? input)
    {
        Action action = () => Password.Create(input!, _hasher);

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Verify_ShouldUseHasher()
    {
        var password = Password.Create("StrongPass1!", _hasher);

        password.Verify("StrongPass1!", _hasher).Should().BeTrue();
        password.Verify("Wrong", _hasher).Should().BeFalse();
    }

    [Fact]
    public void FromHash_ShouldRestoreValueObject()
    {
        var password = Password.FromHash("TEST:Saved");

        password.Hash.Should().Be("TEST:Saved");
    }
}

