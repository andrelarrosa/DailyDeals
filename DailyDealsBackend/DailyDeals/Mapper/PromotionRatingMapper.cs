using DailyDeals.Dto;
using DailyDeals.Infra;

namespace DailyDeals.Mapper;

public class PromotionRatingMapper
{
    private readonly DbContextFac _dbContext;

    public PromotionRatingMapper(DbContextFac dbContext)
    {
        _dbContext = dbContext;
    }
    
    public PromotionRating toDatabase(PromotionRatingDto promotionRatingDto)
    {
        PromotionRating promotionRating = new PromotionRating();
        promotionRating.Score = promotionRatingDto.Score;
        promotionRating.User = _dbContext.Users.FirstOrDefault(u => u.Id == promotionRatingDto.UserId);
        promotionRating.Promotion = _dbContext.Promotions.FirstOrDefault(p => p.Id == promotionRatingDto.PromotionId);
        return promotionRating;
    }

    public PromotionRatingDto toDto(PromotionRating promotionRating)
    {
        PromotionRatingDto promotionRatingDto = new PromotionRatingDto(promotionRating.User.Id, promotionRating.Promotion.Id, promotionRating.Score);
        return promotionRatingDto;
    }
}