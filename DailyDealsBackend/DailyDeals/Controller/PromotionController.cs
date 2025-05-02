using System.Net;
using DailyDeals.Dto;
using DailyDeals.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace DailyDeals.Controller;

[Route("api/[controller]")]
[ApiController]
public class PromotionController : ControllerBase
{
    private readonly IPromotion _promotion;
    
    public PromotionController(IPromotion promotion)
    {
        _promotion = promotion;
    }
    
    [HttpPost]
    [Route("create")]
    public IActionResult CreatePromotion([FromBody]PromotionDto promotionDto)
    {
        try
        {
            _promotion.CreatePromotion(promotionDto);
            return Ok("Promotion created successfully");

        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpGet]
    [Route("getAllPromotions")]
    public async Task<IActionResult> GetAllPromotions()
    {
        try
        {
            var result = await _promotion.GetAllPromotions();
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpPut]
    [Route("update")]
    public IActionResult UpdatePromotion([FromBody] PromotionDto promotionDto, [FromQuery] int id)
    {
        try
        {
            var result = _promotion.UpdatePromotion(promotionDto, id);
            return Ok("Promotion updated successfully");
        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpDelete]
    [Route("delete")]
    public IActionResult DeletePromotion([FromQuery] int id)
    {
        try
        {
            var result = _promotion.DeletePromotion(id);
            return Ok("Promotion deleted successfully");
        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
    }

}