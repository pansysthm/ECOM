using ECOM.Data;
using ECOM.Helper;
using ECOM.Repositories;
using ECOM.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#region Customs services

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEncryptPasswordHelper, EncryptPasswordHelper>();
builder.Services.AddScoped<IUserValidation, UserValidation>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

var app = builder.Build();

app.MapControllers();

app.Run();