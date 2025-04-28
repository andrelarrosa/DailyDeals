using DailyDeals.Dto;
using DailyDeals.Gateway;
using DailyDeals.Infra;
using DailyDeals.Mapper;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task CreateUser(UserDto userDto)
    {
        var transaction = await _context.Database.BeginTransactionAsync();
        
        var user = _userMapper.toDatabase(userDto);
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        
        await transaction.CommitAsync();
    }

    public async Task<List<UserDto>> GetAllUsers()
    {
        
        try
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(user => _userMapper.toDto(user)).ToList();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}