using DailyDeals.Gateway;
using DailyDeals.Infra;
using DailyDeals.Mapper;
using DailyDeals.Service;
using DailyDeals.Validator;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<DbContextFac>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins(allowedOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
//Services
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IPromotionType, PromotionTypeService>();
builder.Services.AddScoped<IPromotion, PromotionService>();
builder.Services.AddScoped<IPromotionRating, PromotionRatingService>();

//Mappers
builder.Services.AddScoped<UserMapper>();
builder.Services.AddScoped<PromotionTypeMapper>();
builder.Services.AddScoped<PromotionMapper>();
builder.Services.AddScoped<PromotionValidator>();
builder.Services.AddScoped<PromotionRatingMapper>();

var app = builder.Build();

app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();