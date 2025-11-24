using System.Linq.Expressions;
using IdentityService.Domain.Interfaces;
using IdentityService.Domain.Models;

namespace IdentityService.Infrastructure.Repositories;

public class RefreshTokeRepository : IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RefreshToken>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RefreshToken>> FindAsync(Expression<Func<RefreshToken, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<RefreshToken?> FirstOrDefaultAsync(Expression<Func<RefreshToken, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync(Expression<Func<RefreshToken, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<RefreshToken> AddAsync(RefreshToken entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(RefreshToken entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(RefreshToken entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CountAsync(Expression<Func<RefreshToken, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<RefreshToken?> GetByTokenWithUserAsync(string token, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RefreshToken>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RefreshToken>> GetValidTokensByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task RevokeTokenAsync(string token, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task RevokeAllUserTokensAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteExpiredTokensAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
