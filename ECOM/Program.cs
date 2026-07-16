using ECOM.Data;
using ECOM.Helper;
using ECOM.Models;
using ECOM.Repositories;
using ECOM.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddOpenApi();
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



// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

app.MapControllers();
// app.UseAuthentication();
// app.UseAuthorization();

app.Run();