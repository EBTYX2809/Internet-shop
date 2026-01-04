using Internet_shop.Application.Contracts.UserContracts;
using Internet_shop.Domain.Models.UserData;
using Internet_shop.Infrastructure.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace Internet_shop.Infrastructure.Repositories.UserRepositories;

public class GoogleUserDataRepository : IGoogleUserDataRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IUserRepository _userRepository;

    public GoogleUserDataRepository(AppDbContext appDbContext, IUserRepository userRepository)
    {
        _appDbContext = appDbContext;
        _userRepository = userRepository;
    }

    public async Task AddGoogleIdAsync(GoogleUserData data)
    {
        var entity = new GoogleUserDataEntity()
        {
            GoogleUserId = data.GoogleUserId,
            UserId = data.UserId
        };
        
        await _appDbContext.GoogleUsersData.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteGoogleUserDataAsync(GoogleUserData data)
    {
        var entity = await _appDbContext.GoogleUsersData
            .FirstOrDefaultAsync(gud => gud.GoogleUserId == data.GoogleUserId && gud.UserId == data.UserId);

        _appDbContext.GoogleUsersData.Remove(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Customer?> GetCustomerByGoogleIdAsync(string googleId)
    {
        var entity = await _appDbContext.GoogleUsersData
            .FirstOrDefaultAsync(gud => gud.GoogleUserId == googleId);

        return await _userRepository.GetCustomerByIdAsync(entity.UserId);
    }
}
