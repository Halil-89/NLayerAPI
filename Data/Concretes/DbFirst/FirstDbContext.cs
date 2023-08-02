using Data.ModelConfigurations;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using NLayer.Core;

namespace Data.Concretes.DbFirst
{
    public class FirstDbContext : DbContext
    {

        public FirstDbContext(DbContextOptions<FirstDbContext> options) : base(options)
        {

        }

        //public DbSet<Product> Products { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        //public DbSet<FaturaUst> FaturaUsts { get; set; }
        //public DbSet<FatKalem> FatKalems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new CustomUserConfiguration());
            //builder.ApplyConfigurationsFromAssembly(GetType().Assembly);//IEntityTypeConfiguration referans alan sınıflara göre Configure eder.

            builder.SeedFirstDb();
            base.OnModelCreating(builder);
        }
    }
}
