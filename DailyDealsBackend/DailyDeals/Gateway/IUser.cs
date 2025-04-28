using DailyDeals.Dto;

namespace DailyDeals.Gateway;

public interface IUser
{
    Task CreateUser(UserDto userDto);
    Task<List<UserDto>> GetAllUsers();
}