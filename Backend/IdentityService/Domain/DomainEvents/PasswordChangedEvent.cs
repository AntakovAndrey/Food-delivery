using IdentityService.Domain.Common;

namespace IdentityService.Domain.DomainEvents;

public class PasswordChangedEvent : DomainEvent
{
    public Guid UserId { get; }
    public DateTime ChangedAt { get; }
    
    public PasswordChangedEvent(Guid userId)
    {
        UserId = userId;
        ChangedAt = DateTime.UtcNow;
    }
}
