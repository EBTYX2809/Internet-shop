namespace Internet_shop.Domain.Models;

public class ProductReview
{
    public Guid ProductId { get; init; }
    public Guid UserId { get; init; }
    public short Score { get; init; }
    public string Review { get; init; }

    public ProductReview(Guid productId, Guid userId, short score, string review)
    {
        if (productId == Guid.Empty)
            throw new ArgumentNullException("productId can't be empty.");

        if (userId == Guid.Empty)
            throw new ArgumentNullException("userId can't be empty.");

        if (score <= 0 || score > 10)
            throw new ArgumentException("Score must be in range from 1 to 10.");

        if (string.IsNullOrWhiteSpace(review) || review.Length > 200)
            throw new ArgumentException("Review can't be empty or large than 200 symbols.");

        ProductId = productId;
        UserId = userId;
        Score = score;
        Review = review;
    }
}
