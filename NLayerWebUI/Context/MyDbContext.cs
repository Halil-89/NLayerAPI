using Microsoft.EntityFrameworkCore;
using NLayerWebUI.Entity;
using NLayerWebUI.Entity.EntityConfiguration;



namespace NLayerWebUI.Context
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }


        public DbSet<FaturaUst> FaturaUsts { get; set; }
        public DbSet<FatKalem> FatKalems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new Configuration());
            modelBuilder.ApplyConfiguration(new FatKalemConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
