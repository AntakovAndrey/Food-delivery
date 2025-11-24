using IdentityService.Domain.Common;

namespace IdentityService.Domain.Models;

public class UserRole : Entity
{
    public Guid UserId { get; private set; }
    public Guid RoleId { get; private set; }
    public DateTime AssignedAt { get; private set; }
    
    public virtual User User { get; private set; } = null!;
    public virtual Role Role { get; private set; } = null!;
    
    private UserRole() { }
    
    public UserRole(Guid userId, Guid roleId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("User ID cannot be empty", nameof(userId));
        
        if (roleId == Guid.Empty)
            throw new ArgumentException("Role ID cannot be empty", nameof(roleId));
        
        UserId = userId;
        RoleId = roleId;
        AssignedAt = DateTime.UtcNow;
    }
}
