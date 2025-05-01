using DailyDeals.Dto;

namespace DailyDeals.Gateway;

public interface IPromotionType
{
    Task CreatePromotionType(PromotionTypeDto promotionTypeDto);
    Task<List<PromotionTypeDto>> GetAllPromotionsTypes();
    Task UpdatePromotionType(PromotionTypeDto promotionTypeDto, int id);
    Task DeletePromotionType(int id);
}