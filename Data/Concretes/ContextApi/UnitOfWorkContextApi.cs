using Data.Abstracts;
using Data.Concretes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concretes.ContextApi
{
    public class UnitOfWorkContextApi : UnitOfWork<ContextApi>, IUnitOfWorkContextApi
    {
        private readonly ContextApi _context;
        private IPersonelRepository _personelRepository;

        public UnitOfWorkContextApi(ContextApi context) : base(context)
        {
            this._context = context;
        }

        public IPersonelRepository PersonelRepository => _personelRepository = _personelRepository ?? new PersonelRepository(_context);


    }
}
