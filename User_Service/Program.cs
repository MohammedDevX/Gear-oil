using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using User_Service.Data;
using User_Service.Models;
using User_Service.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<EmailService>();
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();