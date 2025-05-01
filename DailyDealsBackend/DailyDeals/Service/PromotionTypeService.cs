using DailyDeals.Dto;
using DailyDeals.Gateway;
using DailyDeals.Infra;
using DailyDeals.Mapper;
using Microsoft.EntityFrameworkCore;

namespace DailyDeals.Service;

public class PromotionTypeService : IPromotionType
{
    private readonly DbContextFac _context;
    private readonly PromotionTypeMapper _promotionTypeMapper;
    
    public PromotionTypeService(DbContextFac context, PromotionTypeMapper promotionTypeMapper)
    {
        _context = context;
        _promotionTypeMapper = promotionTypeMapper;
    }
    
    public async Task CreatePromotionType(PromotionTypeDto promotionTypeDto)
    {
        var promotionType = _promotionTypeMapper.toDatabase(promotionTypeDto);
        await _context.PromotionTypes.AddAsync(promotionType);
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<PromotionTypeDto>> GetAllPromotionsTypes()
    {
        
        try
        {
            var promotionsTypes = await _context.PromotionTypes.ToListAsync();
            return promotionsTypes.Select(promotionType => _promotionTypeMapper.toDto(promotionType)).ToList();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task UpdatePromotionType(PromotionTypeDto promotionTypeDto, int id)
    {
        var promotionType = _context.PromotionTypes.FirstOrDefault((x) => x.Id == id);

        if (promotionType == null)
        {
            throw new Exception($"Promotion Type not found with id: {id} ");
        }
        
        promotionType.Name = promotionTypeDto.Name;
        
        _context.PromotionTypes.Update(promotionType);
        await _context.SaveChangesAsync();

    }

    public async Task DeletePromotionType(int id)
    {
        var promotionType = _context.PromotionTypes.FirstOrDefault((x) => x.Id == id);
        if (promotionType == null)
        {
            throw new Exception($"Promotion Type not found with id: {id} ");
        }
        _context.PromotionTypes.Remove(promotionType);
        await _context.SaveChangesAsync();
    }
}