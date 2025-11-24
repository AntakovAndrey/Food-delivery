using IdentityService.Domain.Common;

namespace IdentityService.Domain.Models;

public class RefreshToken : Entity
{
    public Guid UserId { get; private set; }
    public string Token { get; private set; }
    public DateTime ExpiresAt { get; private set; }
    public bool IsRevoked { get; private set; }
    public DateTime? RevokedAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    public virtual User User { get; private set; } = null!;
    
    private RefreshToken() { }
    
    public RefreshToken(Guid userId, string token, DateTime expiresAt)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("User ID cannot be empty", nameof(userId));
        
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("Token cannot be empty", nameof(token));
        
        if (expiresAt <= DateTime.UtcNow)
            throw new ArgumentException("Token expiration must be in the future", nameof(expiresAt));
        
        UserId = userId;
        Token = token;
        ExpiresAt = expiresAt;
        IsRevoked = false;
        CreatedAt = DateTime.UtcNow;
    }
    
    public void Revoke()
    {
        if (IsRevoked)
            throw new InvalidOperationException("Token is already revoked");
        
        IsRevoked = true;
        RevokedAt = DateTime.UtcNow;
    }
    
    public bool IsExpired()
    {
        return DateTime.UtcNow >= ExpiresAt;
    }
    
    public bool IsValid()
    {
        return !IsRevoked && !IsExpired();
    }
}
