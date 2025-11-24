using FluentAssertions;
using IdentityService.Domain.ValueObjects;

namespace IdentityService.Domain.Tests.Domain.ValueObjects;

public class EmailTests
{
    [Theory]
    [InlineData("user@example.com")]
    [InlineData("USER+tag@Example.org")]
    [InlineData("first.last@sub.domain.co")]
    public void Create_WithValidValue_ShouldNormalizeAndStoreLowercase(string input)
    {
        var email = Email.Create(input);

        email.Value.Should().Be(input.ToLowerInvariant());
        email.ToString().Should().Be(email.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("not-an-email")]
    [InlineData("missing-at.com")]
    [InlineData("missing-domain@")]
    public void Create_WithInvalidValue_ShouldThrowArgumentException(string? input)
    {
        Action action = () => Email.Create(input!);

        action.Should().Throw<ArgumentException>();
    }
}

