using IdentityService.Domain.Common;
using IdentityService.Domain.ValueObjects;

namespace IdentityService.Domain.Models;

public class User : Entity
{
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public bool EmailVerified { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    public virtual ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
    public virtual ICollection<RefreshToken> RefreshTokens { get; private set; } = new List<RefreshToken>();
    public virtual ICollection<Address> Addresses { get; private set; } = new List<Address>();
    
    private User() { }
    
    public User(string name, Email email, Password password)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));
        
        Name = name.Trim();
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Password = password ?? throw new ArgumentNullException(nameof(password));
        EmailVerified = false;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));
        
        Name = name.Trim();
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void UpdateEmail(Email email)
    {
        Email = email ?? throw new ArgumentNullException(nameof(email));
        EmailVerified = false;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void ChangePassword(Password newPassword)
    {
        Password = newPassword ?? throw new ArgumentNullException(nameof(newPassword));
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void VerifyEmail()
    {
        EmailVerified = true;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void AddAddress(Address address)
    {
        if (address == null)
            throw new ArgumentNullException(nameof(address));
        
        Addresses.Add(address);
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void RemoveAddress(Address address)
    {
        if (address == null)
            throw new ArgumentNullException(nameof(address));
        
        Addresses.Remove(address);
        UpdatedAt = DateTime.UtcNow;
    }
}
