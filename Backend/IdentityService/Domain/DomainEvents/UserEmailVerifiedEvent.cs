using IdentityService.Domain.Common;

namespace IdentityService.Domain.DomainEvents;

public class UserEmailVerifiedEvent : DomainEvent
{
    public Guid UserId { get; }
    public string Email { get; }
    
    public UserEmailVerifiedEvent(Guid userId, string email)
    {
        UserId = userId;
        Email = email;
    }
}
