using DailyDeals.Dto;

namespace DailyDeals.Gateway;

public interface IUser
{
    Task CreateUser(UserDto userDto);
    Task<List<UserDto>> GetAllUsers();
    Task UpdateUser(UserDto userDto, int id);
    Task DeleteUser(int id);
}