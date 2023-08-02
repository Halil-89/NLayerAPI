using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Concretes.ContextApi
{
    public class ContextApi : DbContext
    {
        public ContextApi()
        {
        }

        public ContextApi(DbContextOptions<ContextApi> options) : base(options)
        {

        }
        public DbSet<Personel> personels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
