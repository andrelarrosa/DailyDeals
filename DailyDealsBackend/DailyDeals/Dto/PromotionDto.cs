namespace DailyDeals.Dto;

public class PromotionDto
{
    public PromotionDto() {}
    
    public PromotionDto(string link, int promotionTypeId, int userId)
    {
        Link = link;
        PromotionTypeId = promotionTypeId;
        UserId = userId;
    }
    
    public string Link { get; set; }
    public int PromotionTypeId { get; set; }
    public int UserId { get; set; }
}