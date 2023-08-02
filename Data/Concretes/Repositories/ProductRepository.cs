using Data.Abstracts;
using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Concretes
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(DbContext context) : base(context)
        {
            //_context = (_context ?? (FirstDbContext)context);
            _context = context;
            _dbSet = context.Set<Product>();
        }



    }
}
