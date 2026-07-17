using ECOM.Data;
using ECOM.Helper;
using ECOM.Repositories;
using ECOM.Services;
using ECOM.Services.TokenService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ECOM.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "ECOM",
            ValidAudience = "ECOM",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#region Customs services

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEncryptPasswordHelper, EncryptPasswordHelper>();
builder.Services.AddScoped<IUserValidation, UserValidation>();
builder.Services.AddScoped<IUserCommand, UserCommand>();
builder.Services.AddScoped<IUserQuery, UserQuery>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();

#endregion

var app = builder.Build();

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();