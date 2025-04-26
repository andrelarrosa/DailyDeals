using DailyDeals.Dto;

namespace DailyDeals.Gateway;

public interface IUser
{
    void createUser(UserDto userDto);
}