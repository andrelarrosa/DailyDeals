using DailyDeals.Dto;
using DailyDeals.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace DailyDeals.Controller;

[Route("api/")]
[ApiController]
public class UserController
{
    private readonly IUser _user;
    
    [HttpPost]
    [Route("create")]
    public void CreateUser([FromBody]UserDto userDto)
    {
        _user.createUser(userDto);    
    }
}