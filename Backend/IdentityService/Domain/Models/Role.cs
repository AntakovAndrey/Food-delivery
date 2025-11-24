using IdentityService.Domain.Common;

namespace IdentityService.Domain.Models;

public class Role : Entity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public ICollection<string> Permissions { get; private set; } = new List<string>();
    
    public virtual ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
    
    private Role() { }
    
    public Role(string name, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Role name cannot be empty", nameof(name));
        
        Name = name.Trim();
        Description = description?.Trim();
    }
    
    public void UpdateDescription(string? description)
    {
        Description = description?.Trim();
    }
    
    public void AddPermission(string permission)
    {
        if (string.IsNullOrWhiteSpace(permission))
            throw new ArgumentException("Permission cannot be empty", nameof(permission));
        
        if (!Permissions.Contains(permission))
        {
            Permissions.Add(permission);
        }
    }
    
    public void RemovePermission(string permission)
    {
        if (string.IsNullOrWhiteSpace(permission))
            throw new ArgumentException("Permission cannot be empty", nameof(permission));
        
        Permissions.Remove(permission);
    }
    
    public bool HasPermission(string permission)
    {
        return Permissions.Contains(permission);
    }
}
