using DailyDeals.Dto;

namespace DailyDeals.Gateway;

public interface IPromotion
{
    Task CreatePromotion(PromotionDto promotionTypeDto);
    Task<List<PromotionDto>> GetAllPromotions();
    Task UpdatePromotion(PromotionDto promotionDto, int id);
    Task DeletePromotion(int id);
}