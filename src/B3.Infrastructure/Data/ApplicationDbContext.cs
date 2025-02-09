using B3.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace B3.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<FinancialProduct> FinancialProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedDatabase(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var bankId = Guid.Parse("70916acf-a375-4b4d-8421-4b365301b0b0");

            modelBuilder.Entity<Bank>().HasData(
                new Bank
                {
                    Id = bankId,
                    Name = "Banco B3 S.A.",
                    Code = "096"
                }
            );

            modelBuilder.Entity<FinancialProduct>().HasData(
                new FinancialProduct
                {
                    Id = Guid.NewGuid(),
                    BankId = bankId,
                    Type = FinancialProductType.CDB,
                    BaseRate = 0.009M,
                    TB = 1.08M
                },
                new FinancialProduct
                {
                    Id = Guid.NewGuid(),
                    BankId = bankId,
                    Type = FinancialProductType.LCI,
                    BaseRate = 0.010M,
                    TB = 1.10M
                }
            );
        }
    }
}
