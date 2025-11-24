using System.Linq.Expressions;
using IdentityService.Domain.Interfaces;
using IdentityService.Domain.Models;
using IdentityService.Domain.ValueObjects;

namespace IdentityService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> FirstOrDefaultAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User> AddAsync(User entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CountAsync(Expression<Func<User, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByEmailWithRolesAsync(Email email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByIdWithRolesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByIdWithAddressesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByIdWithRefreshTokensAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> EmailExistsAsync(Email email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
