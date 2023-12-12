using CustomerB2B.Repositories;
using Microsoft.EntityFrameworkCore;
using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.Repositories.Implementation;
using CustomerB2B.Services.CompanyGroupInfo;
using CustomerB2B.Services.CompanyTypeInfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CustomerB2BDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerB2BConnection")));




builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICompanyGroupInfo, CompanyGroupInfoService>();
builder.Services.AddScoped<ICompanyTypeInfo, CompanyTypeInfoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllers();

app.Run();

