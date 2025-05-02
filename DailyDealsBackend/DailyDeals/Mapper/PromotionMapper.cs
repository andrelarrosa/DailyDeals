using DailyDeals.Dto;
using DailyDeals.Infra;

namespace DailyDeals.Mapper;

public class PromotionMapper
{
    private readonly DbContextFac _dbContext;

    public PromotionMapper(DbContextFac dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Promotion toDatabase(PromotionDto promotionDto)
    {
        Promotion promotion = new Promotion();
        promotion.Link = promotionDto.Link;
        promotion.User = _dbContext.Users.FirstOrDefault(u => u.Id == promotionDto.UserId);
        promotion.PromotionType = _dbContext.PromotionTypes.FirstOrDefault(t => t.Id == promotionDto.PromotionTypeId);
        return promotion;
    }

    public PromotionDto toDto(Promotion promotion)
    {
        PromotionDto promotionDto = new PromotionDto(promotion.Link, promotion.PromotionType.Id, promotion.User.Id);
        return promotionDto;
    }
}