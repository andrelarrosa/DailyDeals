namespace DailyDeals.Dto;

public class PromotionRatingDto
{
    public PromotionRatingDto(int userId, int promotionId, int score)
    {
        UserId = userId;
        PromotionId = promotionId;
        Score = score;
    }
    
    public int UserId { get; set; }
    public int PromotionId { get; set; }
    public int Score { get; set; }
}