namespace DailyDeals.Dto;

public class UserDto
{
    public UserDto(string name, string email, string password, string cpf)
    {
        Name = name;
        Email = email;
        Cpf = cpf;
        Password = password;
    }
    
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public string Password { get; set; }

}