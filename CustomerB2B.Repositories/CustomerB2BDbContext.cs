using CustomerB2B.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerB2B.Repositories
{
    public class CustomerB2BDbContext : IdentityDbContext
    {
        public CustomerB2BDbContext(DbContextOptions<CustomerB2BDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<CompanyGroup> CompanyGroups { get; set; }
        public DbSet<Company> Companíes { get; set; }
        public DbSet<CompanyTypeCompany> CompanyTypeCompany { get; set; }
    }
}
