using FluentAssertions;
using IdentityService.Domain.Models;

namespace IdentityService.Domain.Tests.Domain.Models;

public class RefreshTokenTests
{
    [Fact]
    public void Constructor_WithFutureExpiration_ShouldCreateToken()
    {
        var token = new RefreshToken(Guid.NewGuid(), "token", DateTime.UtcNow.AddHours(1));

        token.Token.Should().Be("token");
        token.IsRevoked.Should().BeFalse();
        token.IsExpired().Should().BeFalse();
        token.IsValid().Should().BeTrue();
    }

    [Fact]
    public void Revoke_ShouldSetFlags()
    {
        var token = new RefreshToken(Guid.NewGuid(), "token", DateTime.UtcNow.AddHours(1));

        token.Revoke();

        token.IsRevoked.Should().BeTrue();
        token.IsValid().Should().BeFalse();
        token.RevokedAt.Should().NotBeNull();
    }

    [Fact]
    public void Constructor_WithPastExpiration_ShouldThrow()
    {
        Action action = () => new RefreshToken(Guid.NewGuid(), "token", DateTime.UtcNow.AddHours(-1));

        action.Should().Throw<ArgumentException>();
    }
}

