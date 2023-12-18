using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CustomerB2B.Repositories
{
    public class CustomerB2BDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public CustomerB2BDbContext(DbContextOptions<CustomerB2BDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CompanyGroup>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyGroup>()
                            .Property(p => p.CreatedBy)
                            .IsRequired(false);

            modelBuilder.Entity<CompanyGroup>()
                .Property(p => p.CreatedDate)
                .IsRequired(false);

            modelBuilder.Entity<CompanyGroup>()
                .Property(p => p.Notice)
                .IsRequired(false);
            modelBuilder.Entity<CompanyGroup>()
               .Property(p => p.IsDeleted)
               .IsRequired(false);
            modelBuilder.Entity<CompanyGroup>()
               .Property(p => p.UpdatedBy)
               .IsRequired(false);
            modelBuilder.Entity<CompanyGroup>()
              .Property(p => p.UpdatedDate)
              .IsRequired(false);


            modelBuilder.Entity<CompanyType>()
              .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyType>()
                            .Property(p => p.CreatedBy)
                            .IsRequired(false);

            modelBuilder.Entity<CompanyType>()
                .Property(p => p.CreatedDate)
                .IsRequired(false);

            modelBuilder.Entity<CompanyType>()
                .Property(p => p.Notice)
                .IsRequired(false);
            modelBuilder.Entity<CompanyType>()
               .Property(p => p.IsDeleted)
               .IsRequired(false);
            modelBuilder.Entity<CompanyType>()
               .Property(p => p.UpdatedBy)
               .IsRequired(false);
            modelBuilder.Entity<CompanyType>()
              .Property(p => p.UpdatedDate)
              .IsRequired(false);



            modelBuilder.Entity<Company>()
             .HasKey(p => p.Id);

            modelBuilder.Entity<Company>()
                            .Property(p => p.CreatedBy)
                            .IsRequired(false);

            modelBuilder.Entity<Company>()
                .Property(p => p.CreatedDate)
                .IsRequired(false);

            modelBuilder.Entity<Company>()
                .Property(p => p.Notice)
                .IsRequired(false);
            modelBuilder.Entity<Company>()
               .Property(p => p.IsDeleted)
               .IsRequired(false);
            modelBuilder.Entity<Company>()
               .Property(p => p.UpdatedBy)
               .IsRequired(false);
            modelBuilder.Entity<Company>()
              .Property(p => p.UpdatedDate)
              .IsRequired(false);
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
