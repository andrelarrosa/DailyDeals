using DailyDeals.Dto;
using DailyDeals.Gateway;
using DailyDeals.Infra;
using DailyDeals.Mapper;
using DailyDeals.Validator;
using Microsoft.EntityFrameworkCore;

namespace DailyDeals.Service;

public class PromotionService : IPromotion
{
    private readonly DbContextFac _context;
    private readonly PromotionMapper _mapper;
    private readonly PromotionValidator _validator;

    public PromotionService(DbContextFac context, PromotionMapper mapper, PromotionValidator validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }
    
    public async Task CreatePromotion(PromotionDto promotionDto)
    {
        var promotion = _mapper.toDatabase(promotionDto);
        await _context.Promotions.AddAsync(promotion);
        await _context.SaveChangesAsync();
    }

    public async Task<List<PromotionDto>> GetAllPromotions()
    {
        try
        {
            var promotions = await _context.Promotions
                .Include(p => p.User)
                .Include(p => p.PromotionType)
                .ToListAsync();
            return promotions.Select(promotion => _mapper.toDto(promotion)).ToList();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task UpdatePromotion(PromotionDto promotionDto, int id)
    {
        try
        {
            _validator.Validate(id, promotionDto.UserId, promotionDto.PromotionTypeId);
            
            var promotion = _context.Promotions
                .Include(p => p.User)
                .Include(p => p.PromotionType)
                .FirstOrDefault(x => x.Id == id);

            var newUser = _context.Users.FirstOrDefault(x => x.Id == promotionDto.UserId);
            var newPromotionType = _context.PromotionTypes.FirstOrDefault(x => x.Id == promotionDto.PromotionTypeId);


            promotion.User = newUser;
            promotion.PromotionType = newPromotionType;
            promotion.Link = promotionDto.Link;

            _context.Promotions.Update(promotion);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception(ex.Message);
        }
        
    }

    public Task DeletePromotion(int id)
    {
        var promotion = _context.Promotions.FirstOrDefault(x => x.Id == id);
        if (promotion == null)
        {
            throw new Exception($"Promotion with id {id} not found");
        }
        _context.Promotions.Remove(promotion);
        return _context.SaveChangesAsync();
    }
}