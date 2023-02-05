using AutoMapper;
using FSEJwtApp.Back.Core.Application.Interfaces;
using FSEJwtApp.Back.Core.Application.Mappings;
using FSEJwtApp.Back.Infrastructure.Tools;
using FSEJwtApp.Back.Persistance.Context;
using FSEJwtApp.Back.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.RequireHttpsMetadata = false;
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidAudience=JwtTokenDefaults.ValidAudience,
            ValidIssuer=JwtTokenDefaults.ValidIssuer,
            ClockSkew=TimeSpan.Zero,
            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes
            (JwtTokenDefaults.Key)),
            ValidateIssuerSigningKey=true,
            ValidateLifetime=true,
        };
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FSEJwtContext>(opt=>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>()
    {
        new ProductProfile(),
        new CategoryProfile(),
    });
});

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
