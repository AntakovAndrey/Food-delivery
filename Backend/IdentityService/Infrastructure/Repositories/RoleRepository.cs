using System.Linq.Expressions;
using IdentityService.Domain.Interfaces;
using IdentityService.Domain.Models;

namespace IdentityService.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    public async Task<Role?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Role>> FindAsync(Expression<Func<Role, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Role?> FirstOrDefaultAsync(Expression<Func<Role, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync(Expression<Func<Role, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Role> AddAsync(Role entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Role entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Role entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CountAsync(Expression<Func<Role, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Role?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Role?> GetByIdWithUsersAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RoleExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Role>> GetRolesByUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}