using DailyDeals.Dto;
using DailyDeals.Gateway;
using DailyDeals.Infra;
using DailyDeals.Mapper;

namespace DailyDeals.Service;

public class UserService : IUser
{
    private readonly DbContextFac _context;
    private readonly UserMapper _userMapper;

    public UserService(DbContextFac context, UserMapper userMapper)
    {
        _context = context;
        _userMapper = userMapper;
    }
    
    public void createUser(UserDto userDto)
    {
        try
        {
            var user = _userMapper.toDatabase(userDto);
            _context.Users.Add(user);
            _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}