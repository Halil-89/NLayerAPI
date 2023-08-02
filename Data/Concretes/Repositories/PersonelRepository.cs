using Data.Abstracts;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concretes.Repositories
{
    public class PersonelRepository : GenericRepository<Personel>, IPersonelRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Personel> _dbSet;
        public PersonelRepository(DbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Personel>();
        }


    }
}
