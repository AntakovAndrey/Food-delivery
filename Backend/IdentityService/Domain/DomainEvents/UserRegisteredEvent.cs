using IdentityService.Domain.Common;

namespace IdentityService.Domain.DomainEvents;

public class UserRegisteredEvent : DomainEvent
{
    public Guid UserId { get; }
    public string Email { get; }
    public string Name { get; }
    
    public UserRegisteredEvent(Guid userId, string email, string name)
    {
        UserId = userId;
        Email = email;
        Name = name;
    }
}
