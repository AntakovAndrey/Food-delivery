using IdentityService.Domain.ValueObjects;

namespace IdentityService.Domain.Tests.TestUtilities;

public sealed class FakePasswordHasher : IPasswordHasher
{
    private readonly string _hashPrefix;

    public FakePasswordHasher(string hashPrefix = "HASH")
    {
        _hashPrefix = hashPrefix;
    }

    public string HashPassword(string plainPassword)
    {
        return $"{_hashPrefix}:{plainPassword}";
    }

    public bool VerifyPassword(string plainPassword, string hash)
    {
        return hash == HashPassword(plainPassword);
    }
}

