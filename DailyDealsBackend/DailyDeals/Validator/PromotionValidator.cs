using DailyDeals.Dto;
using DailyDeals.Infra;
using Microsoft.EntityFrameworkCore;

namespace DailyDeals.Validator;

public class PromotionValidator
{
    private readonly DbContextFac _dbContext;

    public PromotionValidator(DbContextFac dbContext)
    {
        _dbContext = dbContext;
    }

    public void Validate(int promotionId, int userId, int promotionTypeId)
    {
        ValidateExistsPromotion(promotionId);
        ValidateExistsUser(userId); 
        ValidateExistsPromotionType(promotionTypeId);
    }
    
    private void ValidateExistsPromotion(int id)
    {
        var exists = _dbContext.Promotions.Any(promotion => promotion.Id == id);
        if (!exists)
            throw new Exception($"Promotion with id {id} does not exist");
    }
    
    private void ValidateExistsUser(int userId)
    {
        var exists = _dbContext.Users.Any(user => user.Id == userId);
        if (!exists)
            throw new Exception($"User with id: {userId} not found");
    }
    
    private void ValidateExistsPromotionType(int promotionTypeId)
    {
        var exists = _dbContext.PromotionTypes.Any(promotionType => promotionType.Id == promotionTypeId);
        if (!exists)
            throw new Exception($"Promotion type with id: {promotionTypeId} not found");
    }
}