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
        var user = _userMapper.toDatabase(userDto);
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
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

    public async Task UpdateUser(UserDto userDto, int id)
    {
        var user = _context.Users.FirstOrDefault((x) => x.Id == id);
        
        user.Name = userDto.Name;
        user.Password = userDto.Password;
        user.Cpf = userDto.Cpf;
        user.Email = userDto.Email;
        
        _context.Users.Update(user);
        await _context.SaveChangesAsync();

    }

    public async Task DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault((x) => x.Id == id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}