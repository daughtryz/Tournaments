using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Tournament.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost9000",
        builder => builder.WithOrigins("http://localhost:9000", "http://10.14.12.26:9500")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("GeneralClaims", policy =>
//    {
//        policy.RequireClaim(ClaimTypes.Name)
//        .RequireClaim(ClaimTypes.Email);
//    });
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TournamentsDbContext>(options =>
{
    options.UseSqlServer("Data Source=CMP-00238\\SQLEXPRESS;Initial Catalog=Tournaments;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
});

// Configure ASP.NET Core Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
.AddEntityFrameworkStores<TournamentsDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"]))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost9000");

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
