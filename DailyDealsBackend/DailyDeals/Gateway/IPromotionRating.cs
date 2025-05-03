using DailyDeals.Dto;

namespace DailyDeals.Gateway;

public interface IPromotionRating
{
    Task CreatePromotionRating(PromotionRatingDto promotionTypeDto);
    Task<List<PromotionRatingDto>> GetAllPromotionRating();
    Task UpdatePromotionRating(PromotionRatingDto promotionDto, int id);
}