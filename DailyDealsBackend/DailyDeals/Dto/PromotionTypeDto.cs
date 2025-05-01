namespace DailyDeals.Dto;

public class PromotionTypeDto
{
    public PromotionTypeDto(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
}