namespace Internet_shop.Infrastructure.Entities.UserEntities;

internal class RefreshTokenEntity
{
    public Guid Id { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsRevoked { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = new();
}
