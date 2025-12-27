namespace Internet_shop.Domain.Models.UserData;

public class GoogleUserData
{
    public string GoogleUserId { get; init; }
    public Guid UserId { get; init; }

    public GoogleUserData(string googleUserId, Guid userId)
    {
        GoogleUserId = googleUserId;
        UserId = userId;
    }
}
