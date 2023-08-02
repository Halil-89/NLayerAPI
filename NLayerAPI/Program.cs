using Business;
using Business.Abstracts;
using Business.Services;
using Data.Abstracts;
using Data.Concretes;
using Data.Concretes.ContextApi;
using Data.Concretes.DbFirst;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using NLayer.API.Infrastructure.Tools;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,

    };
});

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<FirstDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerFirst"), sqlOptions =>
    {
        sqlOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(FirstDbContext)).GetName().Name);
    });
});

builder.Services.AddDbContext<SecondDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerSecond"), sqlOptions =>
    {
        sqlOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(SecondDbContext)).GetName().Name);
    });
});

builder.Services.AddDbContext<ContextApi>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerApi"), sqlOptions =>
    {
        sqlOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(ContextApi)).GetName().Name);
    });
});



builder.Services.AddScoped<IUnitOfWorkFirstDb, UnitOfWorkFirstDb>();
builder.Services.AddScoped<IUnitOfWorkSecondDb, UnitOfWorkSecondDb>();
builder.Services.AddScoped<IUnitOfWorkContextApi, UnitOfWorkContextApi>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IPersonelService, PersonelService>();








// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
