using IdentityService.Domain.Common;

namespace IdentityService.Domain.ValueObjects;

public class Password : ValueObject
{
    public string Hash { get; private set; }
    
    private Password(string hash)
    {
        if (string.IsNullOrWhiteSpace(hash))
            throw new ArgumentException("Password hash cannot be empty", nameof(hash));
        
        Hash = hash;
    }
    
    public static Password Create(string plainPassword, IPasswordHasher hasher)
    {
        if (string.IsNullOrWhiteSpace(plainPassword))
            throw new ArgumentException("Password cannot be empty", nameof(plainPassword));
        
        if (plainPassword.Length < 8)
            throw new ArgumentException("Password must be at least 8 characters", nameof(plainPassword));
        
        if (plainPassword.Length > 128)
            throw new ArgumentException("Password cannot exceed 128 characters", nameof(plainPassword));
        
        var hash = hasher.HashPassword(plainPassword);
        return new Password(hash);
    }
    
    public static Password FromHash(string hash)
    {
        return new Password(hash);
    }
    
    public bool Verify(string plainPassword, IPasswordHasher hasher)
    {
        if (string.IsNullOrWhiteSpace(plainPassword))
            return false;
        
        return hasher.VerifyPassword(plainPassword, Hash);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Hash;
    }
}

public interface IPasswordHasher
{
    string HashPassword(string plainPassword);
    bool VerifyPassword(string plainPassword, string hash);
}

