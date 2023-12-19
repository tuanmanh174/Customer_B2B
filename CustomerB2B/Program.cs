using CustomerB2B.Repositories;
using Microsoft.EntityFrameworkCore;
using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.Repositories.Implementation;
using CustomerB2B.Services.CompanyGroupInfo;
using CustomerB2B.Services.CompanyTypeInfo;
using CustomerB2B.Services.CompanyTypeCompanyInfo;
using CustomerB2B.Services.CompanyDocumentInfo;
using CustomerB2B.Services.CompanyInfo;
using CustomerB2B.Services.CompanyRepresentativeInfo;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using CustomerB2B.Services.CompanyAdditionalInfo;
using CustomerB2B.Services.CompanyCopperationInfo;
using CustomerB2B.Services.ICompanySpecificInfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CustomerB2BDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerB2BConnection")));



// Apply migration here




builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICompanyGroupInfo, CompanyGroupInfoService>();
builder.Services.AddScoped<ICompanyTypeInfo, CompanyTypeInfoService>();
builder.Services.AddScoped<ICompanyTypeCompanyInfo, CompanyTypeCompnayInfoService>();
builder.Services.AddScoped<ICompanyDocumentInfo, CompanyDocumentInfoService>();
builder.Services.AddScoped<ICompanyInfo, CompanyInfoService>();
builder.Services.AddScoped<ICompanyRepresentativeInfo, CompanyRepresentativeInfoService>();
builder.Services.AddScoped<ICompanyAdditionalInfo, CompanyAdditionalInfoService>();
builder.Services.AddScoped<ICompanyCopperationInfo, CompanyCopperationInfoService>();
builder.Services.AddScoped<ICompanySpecificInfo, CompanySpecificService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CustomerB2BDbContext>();
    dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllers();

app.Run();


