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

    public async Task Validate(int promotionId, int userId, int promotionTypeId)
    {
       await ValidateExistsPromotion(promotionId);
       await ValidateExistsUser(userId);
       await ValidateExistsPromotionType(promotionTypeId);
    }
    
    private async Task ValidateExistsPromotion(int id)
    {
        var exists = await _dbContext.Promotions.AnyAsync(promotion => promotion.Id == id);
        if (!exists)
            throw new Exception($"Promotion with id {id} does not exist");
    }
    
    private async Task ValidateExistsUser(int userId)
    {
        var exists = await _dbContext.Users.AnyAsync(user => user.Id == userId);
        if (!exists)
            throw new Exception($"User with id: {userId} not found");
    }
    
    private async Task ValidateExistsPromotionType(int promotionTypeId)
    {
        var exists = await _dbContext.PromotionTypes.AnyAsync(promotionType => promotionType.Id == promotionTypeId);
        if (!exists)
            throw new Exception($"Promotion type with id: {promotionTypeId} not found");
    }
}