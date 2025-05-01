using System.Net;
using DailyDeals.Dto;
using DailyDeals.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace DailyDeals.Controller;

[Route("api/[controller]")]
[ApiController]
public class PromotionTypeController : ControllerBase
{
    private readonly IPromotionType _promotionType;

    public PromotionTypeController(IPromotionType promotionType)
    {
        _promotionType = promotionType;
    }
    
    [HttpPost]
    [Route("create")]
    public IActionResult CreatePromotionType([FromBody]PromotionTypeDto promotionTypeDto)
    {
        try
        {
            _promotionType.CreatePromotionType(promotionTypeDto);
            return Ok("Promotion Type created");

        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
    }
    
    
    [HttpGet]
    [Route("getPromotionsTypes")]
    public IActionResult GetPromotionsTypes()
    {
        try
        {
            var result = _promotionType.GetAllPromotionsTypes();
            return Ok(result.Result);
        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpPut]
    [Route("update")]
    public IActionResult UpdatePromotionType([FromBody] PromotionTypeDto promotionTypeDto, [FromQuery] int id)
    {
        try
        {
            var result = _promotionType.UpdatePromotionType(promotionTypeDto, id);
            return Ok("User updated successfully with id: " + result.Id);
        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpDelete]
    [Route("delete")]
    public IActionResult DeletePromotionType([FromQuery] int id)
    {
        try
        {
            var result = _promotionType.DeletePromotionType(id);
            return Ok("User deleted successfully");
        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
        
    }
}