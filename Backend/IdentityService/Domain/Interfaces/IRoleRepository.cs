using IdentityService.Domain.Models;

namespace IdentityService.Domain.Interfaces;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<Role?> GetByIdWithUsersAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> RoleExistsAsync(string name, CancellationToken cancellationToken = default);
    Task<IEnumerable<Role>> GetRolesByUserAsync(Guid userId, CancellationToken cancellationToken = default);
}

