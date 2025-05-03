using System.Net;
using DailyDeals.Dto;
using DailyDeals.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace DailyDeals.Controller;

[Route("api/[controller]")]
[ApiController]
public class PromotionRatingController : ControllerBase
{
    private readonly IPromotionRating _promotionRating;

    public PromotionRatingController(IPromotionRating promotionRating)
    {
        _promotionRating = promotionRating;
    }
    
    [HttpPost]
    [Route("create")]
    public IActionResult CreatePromotion([FromBody]PromotionRatingDto promotionRatingDto)
    {
        try
        {
            _promotionRating.CreatePromotionRating(promotionRatingDto);
            return Ok("Rating created successfully");

        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpGet]
    [Route("getAllPromotionsRating")]
    public async Task<IActionResult> GetAllPromotions()
    {
        try
        {
            var result = await _promotionRating.GetAllPromotionRating();
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpPut]
    [Route("update")]
    public IActionResult UpdatePromotion([FromBody] PromotionRatingDto promotionRatingDto, [FromQuery] int id)
    {
        try
        {
            var result = _promotionRating.UpdatePromotionRating(promotionRatingDto, id);
            return Ok("Rating updated successfully");
        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
    }
}