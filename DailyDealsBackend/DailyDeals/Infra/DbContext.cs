using Microsoft.EntityFrameworkCore;

namespace DailyDeals.Infra;

public class DbContextFac : DbContext
{
    public DbContextFac(DbContextOptions<DbContextFac> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<PromotionType> PromotionTypes { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<PromotionRating> PromotionRatings { get; set; }
    
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

public class Promotion
{
    public int Id { get; set; }
    public string Link { get; set; }
    public User User { get; set; }
    public PromotionType PromotionType { get; set; }
}

public class PromotionRating
{
    public int Id { get; set; }
    public User User { get; set; }
    public Promotion Promotion { get; set; }
    public int Score { get; set; }
}