using Data.Abstracts;

namespace Data.Concretes
{
    public class UnitOfWorkSecondDb : UnitOfWork<SecondDbContext>, IUnitOfWorkSecondDb
    {
        private readonly SecondDbContext _context;
        private ICustomerRepository _customerRepository;
        public UnitOfWorkSecondDb(SecondDbContext context) : base(context)
        {
            this._context = context;
        }
        public ICustomerRepository CustomerRepository => _customerRepository = _customerRepository ?? new CustomerRepository(_context);
    }

}
