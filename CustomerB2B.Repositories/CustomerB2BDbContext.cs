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
            modelBuilder.Entity<CompanyAdditionalInformation>()
              .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyAdditionalInformation>()
                            .Property(p => p.CompanyId)
                            .IsRequired(false);
            modelBuilder.Entity<CompanyAdditionalInformation>()
                           .Property(p => p.AccountBank)
                           .IsRequired(false);
            modelBuilder.Entity<CompanyAdditionalInformation>()
                           .Property(p => p.BankName)
                           .IsRequired(false);
            modelBuilder.Entity<CompanyAdditionalInformation>()
                          .Property(p => p.CustomerFrom)
                          .IsRequired(false);



            modelBuilder.Entity<CompanyCopperationInformation>()
              .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyCopperationInformation>()
                            .Property(p => p.CompanyId)
                            .IsRequired(false);
            modelBuilder.Entity<CompanyCopperationInformation>()
                          .Property(p => p.CooperationField)
                          .IsRequired(false);
            modelBuilder.Entity<CompanyCopperationInformation>()
                          .Property(p => p.CooperationOther)
                          .IsRequired(false);
            modelBuilder.Entity<CompanyCopperationInformation>()
                          .Property(p => p.Product)
                          .IsRequired(false);
            modelBuilder.Entity<CompanyCopperationInformation>()
                          .Property(p => p.CoordinatingAgent)
                          .IsRequired(false);


            modelBuilder.Entity<CompanyGroup>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyGroup>()
                            .Property(p => p.CreatedBy)
                            .IsRequired(false);

            modelBuilder.Entity<CompanyGroup>()
                .Property(p => p.CreatedDate)
                .IsRequired(false);
            modelBuilder.Entity<CompanyGroup>()
               .Property(p => p.Name)
               .IsRequired(false);
            modelBuilder.Entity<CompanyGroup>()
               .Property(p => p.Code)
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
            modelBuilder.Entity<CompanyType>()
               .Property(p => p.Code)
               .IsRequired(false);
            modelBuilder.Entity<CompanyType>()
               .Property(p => p.Name)
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
            modelBuilder.Entity<Company>()
            .Property(p => p.Address)
            .IsRequired(false);
            modelBuilder.Entity<Company>()
           .Property(p => p.City)
           .IsRequired(false);
            modelBuilder.Entity<Company>()
          .Property(p => p.DistrictId)
          .IsRequired(false);
            modelBuilder.Entity<Company>()
         .Property(p => p.Email)
         .IsRequired(false);
            modelBuilder.Entity<Company>()
        .Property(p => p.TaxCode)
        .IsRequired(false);
            modelBuilder.Entity<Company>()
       .Property(p => p.GroupId)
       .IsRequired(false);
            modelBuilder.Entity<Company>()
       .Property(p => p.Field)
       .IsRequired(false);
            modelBuilder.Entity<Company>()
       .Property(p => p.ShortName)
       .IsRequired(false);
            modelBuilder.Entity<Company>()
       .Property(p => p.Website)
       .IsRequired(false);


            modelBuilder.Entity<CompanyDocument>()
                 .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyDocument>()
                            .Property(p => p.CompanyId)
                            .IsRequired(false);
            modelBuilder.Entity<CompanyDocument>()
                           .Property(p => p.DocumentName)
                           .IsRequired(false);
            modelBuilder.Entity<CompanyDocument>()
                          .Property(p => p.Path)
                          .IsRequired(false);



            modelBuilder.Entity<CompanyRepresentative>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyRepresentative>()
                            .Property(p => p.Name)
                            .IsRequired(false);
            modelBuilder.Entity<CompanyRepresentative>()
                           .Property(p => p.Position)
                           .IsRequired(false);
            modelBuilder.Entity<CompanyRepresentative>()
                       .Property(p => p.Email)
                       .IsRequired(false);
            modelBuilder.Entity<CompanyRepresentative>()
                      .Property(p => p.CompanyId)
                      .IsRequired(false);


            modelBuilder.Entity<CompanySpecificInformation>()
             .HasKey(p => p.Id);

            modelBuilder.Entity<CompanySpecificInformation>()
                            .Property(p => p.Title)
                            .IsRequired(false);
            modelBuilder.Entity<CompanySpecificInformation>()
                           .Property(p => p.Description)
                           .IsRequired(false);
            modelBuilder.Entity<CompanySpecificInformation>()
                          .Property(p => p.CompanyId)
                          .IsRequired(false);


            modelBuilder.Entity<CompanyTypeCompany>()
            .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyTypeCompany>()
                            .Property(p => p.CompanyId)
                            .IsRequired(false);
            modelBuilder.Entity<CompanyTypeCompany>()
                           .Property(p => p.CompanyTypeId)
                           .IsRequired(false);

        }


        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<CompanyGroup> CompanyGroups { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyTypeCompany> CompanyTypeCompany { get; set; }
        public DbSet<CompanyRepresentative> CompanyRepresentatives { get; set; }
        public DbSet<CompanyDocument> CompanyDocuments { get; set; }
        public DbSet<CompanySpecificInformation> CompanySpecificInformations { get; set; }
        public DbSet<CompanyAdditionalInformation> CompanyAdditionalInformations { get; set; }
        public DbSet<CompanyCopperationInformation> CompanyCopperationInformations { get; set; }

    }
}
