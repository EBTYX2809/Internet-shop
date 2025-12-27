using System.Security.Cryptography;

namespace Internet_shop.Domain.Models.UserData;

public class RefreshToken
{
    public Guid Id { get; init; }
    public string Token { get; init; } = string.Empty;
    public DateTime ExpiresAt { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public bool IsRevoked { get; private set; }
    public Guid UserId { get; init; }

    public RefreshToken(Guid userId)
    {
        Id = Guid.NewGuid();
        Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        ExpiresAt = DateTime.UtcNow.AddDays(7);
        CreatedAt = DateTime.UtcNow;
        IsRevoked = false;
        UserId = userId;
    }

    public RefreshToken(Guid id, Guid userId)
    {
        Id = id;
        Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        ExpiresAt = DateTime.UtcNow.AddDays(7);
        CreatedAt = DateTime.UtcNow;
        IsRevoked = false;
        UserId = userId;
    }
}