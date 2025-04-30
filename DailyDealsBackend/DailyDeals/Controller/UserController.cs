using System.Net;
using DailyDeals.Dto;
using DailyDeals.Gateway;
using Microsoft.AspNetCore.Mvc;


namespace DailyDeals.Controller;

[Route("api/")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUser _user;
    
    public UserController(IUser user)
    {
        _user = user;
    }
    
    [HttpPost]
    [Route("create")]
    public IActionResult CreateUser([FromBody]UserDto userDto)
    {
        try
        {
            _user.CreateUser(userDto);
            return Ok("User created successfully");
        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpGet]
    [Route("getUsers")]
    public IActionResult GetUsers()
    {
        try
        {
            var result = _user.GetAllUsers();
            return Ok(result.Result);
        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpPut]
    [Route("update")]
    public IActionResult UpdateUser([FromBody] UserDto userDto, [FromQuery] int id)
    {
        try
        {
            var result = _user.UpdateUser(userDto, id);
            return Ok("User updated successfully with id: " + result.Id);
        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpDelete]
    [Route("delete")]
    public IActionResult DeleteUser([FromQuery] int id)
    {
        try
        {
            var result = _user.DeleteUser(id);
            return Ok("User deleted successfully");
        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
        }
        
    }
}