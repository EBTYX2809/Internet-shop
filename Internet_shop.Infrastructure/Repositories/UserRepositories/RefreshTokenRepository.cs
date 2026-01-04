using Internet_shop.Application.Contracts.UserContracts;
using Internet_shop.Domain.Models.UserData;
using Internet_shop.Infrastructure.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace Internet_shop.Infrastructure.Repositories.UserRepositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly AppDbContext _appDbContext;

    public RefreshTokenRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddTokenAsync(RefreshToken token)
    {
        var tokenEntity = new RefreshTokenEntity()
        {
            Id = token.Id,
            UserId = token.UserId,
            Token = token.Token,
            ExpiresAt = token.ExpiresAt,
            CreatedAt = token.CreatedAt,
            IsRevoked = token.IsRevoked
        };

        await _appDbContext.RefreshTokens.AddAsync(tokenEntity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteTokenAsync(RefreshToken token)
    {
        var tokenEntity = await _appDbContext.RefreshTokens.FirstOrDefaultAsync(rf => rf.Id == token.Id);

        _appDbContext.RefreshTokens.Remove(tokenEntity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<RefreshToken?> GetRefreshTokenAsync(Guid id)
    {
        var tokenEntity = await _appDbContext.RefreshTokens.FirstOrDefaultAsync(rf => rf.Id == id);

        var token = new RefreshToken(
                tokenEntity.Id,
                tokenEntity.Token,
                tokenEntity.ExpiresAt,
                tokenEntity.CreatedAt,
                tokenEntity.IsRevoked,
                tokenEntity.UserId);

        return token;
    }

    public async Task RevokeTokenAsync(Guid id)
    {
        var tokenEntity = await _appDbContext.RefreshTokens.FirstOrDefaultAsync(rf => rf.Id == id);

        tokenEntity.IsRevoked = true;

        await _appDbContext.SaveChangesAsync();
    }
}
