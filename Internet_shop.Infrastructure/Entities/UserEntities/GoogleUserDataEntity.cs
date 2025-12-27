namespace Internet_shop.Infrastructure.Entities.UserEntities;

internal class GoogleUserDataEntity
{
    public string GoogleUserId { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = new();
}
