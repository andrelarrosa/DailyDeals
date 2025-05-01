using DailyDeals.Dto;
using DailyDeals.Infra;

namespace DailyDeals.Mapper;

public class PromotionTypeMapper
{
    public PromotionType toDatabase(PromotionTypeDto promotionTypeDto)
    {
        PromotionType promotionType = new PromotionType();
        promotionType.Name = promotionTypeDto.Name;
        return promotionType;
    }
    
    public PromotionTypeDto toDto(PromotionType promotionType)
    {
        PromotionTypeDto promotionTypeDto = new PromotionTypeDto(promotionType.Name);
        return promotionTypeDto;
    }
}