using CustomerB2B.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using CustomerB2B.Utilities;
using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CustomerB2BDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerB2BConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<CustomerB2BDbContext>();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CustomerB2BDbContext>();

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<CustomerB2BDbContext>();

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
DataSedding();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllers();

app.Run();

void DataSedding()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.
            GetRequiredService<IDbSetInitializer>();
        //dbInitializer.InitializeSets();
    }
}
