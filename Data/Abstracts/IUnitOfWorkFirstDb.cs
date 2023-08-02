using Data.Concretes.DbFirst;


namespace Data.Abstracts
{
    public interface IUnitOfWorkFirstDb : IUnitOfWork<FirstDbContext>
    {
        IProductRepository ProductRepository { get; }

    }
}
