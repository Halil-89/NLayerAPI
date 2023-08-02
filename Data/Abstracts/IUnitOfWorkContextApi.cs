using Data.Concretes;
using Data.Concretes.ContextApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstracts
{
    public  interface IUnitOfWorkContextApi : IUnitOfWork<ContextApi>
    {
        IPersonelRepository PersonelRepository { get; }
    }
}
