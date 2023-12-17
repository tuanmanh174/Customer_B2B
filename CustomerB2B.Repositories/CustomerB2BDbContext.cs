using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerB2B.Repositories
{
    public class CustomerB2BDbContext : IdentityDbContext
    {
        public CustomerB2BDbContext(DbContextOptions<CustomerB2BDbContext> options) : base(options)
        {

        }

        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<CompanyGroup> CompanyGroups { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyTypeCompany> CompanyTypeCompany { get; set; }
        public DbSet<CompanyRepresentative> CompanyRepresentatives { get; set; }
        public DbSet<CompanyDocument> CompanyDocuments { get; set; }
        public DbSet<CompanySpecificInformation> CompanySpecificInformations { get; set; }
    }
}
