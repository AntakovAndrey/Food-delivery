using IdentityService.Domain.Models;

namespace IdentityService.Domain.Interfaces;

public interface IAddressRepository : IRepository<Address>
{
    Task<IEnumerable<Address>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Address?> GetDefaultAddressByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task SetAsDefaultAsync(Guid addressId, Guid userId, CancellationToken cancellationToken = default);
    Task RemoveDefaultFromUserAddressesAsync(Guid userId, CancellationToken cancellationToken = default);
}

