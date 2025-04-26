using DailyDeals.Dto;
using DailyDeals.Infra;

namespace DailyDeals.Mapper;

public class UserMapper
{
    public User toDatabase(UserDto userDto)
    {
        User user = new User();
        user.Cpf = userDto.Cpf;
        user.Email = userDto.Email;
        user.Name = userDto.Name;
        user.Password = userDto.Password;
        return user;
    }
}