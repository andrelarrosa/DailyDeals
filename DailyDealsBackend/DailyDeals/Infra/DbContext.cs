using Microsoft.EntityFrameworkCore;

namespace DailyDeals.Infra;

public class DbContextFac : DbContext
{
    public DbContextFac(DbContextOptions<DbContextFac> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<PromotionType> PromotionTypes { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Cpf { get; set; }
}

public class PromotionType
{
    public int Id { get; set; }
    public string Name { get; set; }
}