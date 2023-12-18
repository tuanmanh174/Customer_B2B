using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomerB2B.Repositories
{
    public class CustomerB2BDbContext : IdentityDbContext
    {
        private readonly IConfiguration _configuration;
        public CustomerB2BDbContext(DbContextOptions<CustomerB2BDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
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
