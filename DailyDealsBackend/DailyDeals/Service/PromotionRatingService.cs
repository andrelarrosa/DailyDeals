using DailyDeals.Dto;
using DailyDeals.Gateway;
using DailyDeals.Infra;
using DailyDeals.Mapper;
using Microsoft.EntityFrameworkCore;

namespace DailyDeals.Service;

public class PromotionRatingService : IPromotionRating
{
    private readonly DbContextFac _context;
    private readonly PromotionRatingMapper _promotionRatingMapper;

    public PromotionRatingService(DbContextFac context, PromotionRatingMapper promotionRatingMapper)
    {
        _context = context;
        _promotionRatingMapper = promotionRatingMapper;
    }
    
    public async Task CreatePromotionRating(PromotionRatingDto promotionTypeDto)
    {
        var promotionRating = _promotionRatingMapper.toDatabase(promotionTypeDto);
        await _context.PromotionRatings.AddAsync(promotionRating);
        await _context.SaveChangesAsync();
    }

    public async Task<List<PromotionRatingDto>> GetAllPromotionRating()
    {
        try
        {
            var promotions = await _context.PromotionRatings
                .Include(p => p.User)
                .Include(p => p.Promotion)
                .ToListAsync();
            return promotions.Select(promotion => _promotionRatingMapper.toDto(promotion)).ToList();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task UpdatePromotionRating(PromotionRatingDto promotionDto, int id)
    {
        try
        {
            var promotion = _context.PromotionRatings
                .Include(p => p.User)
                .Include(p => p.Promotion)
                .FirstOrDefault(x => x.Id == id);

            var newUser = _context.Users.FirstOrDefault(x => x.Id == promotionDto.UserId);
            var newPromotion = _context.Promotions.FirstOrDefault(x => x.Id == promotionDto.PromotionId);


            promotion.User = newUser;
            promotion.Promotion = newPromotion;
            promotion.Score = promotionDto.Score;

            _context.PromotionRatings.Update(promotion);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}