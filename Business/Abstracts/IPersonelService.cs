using Entity.Models;
using Entity.ModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IPersonelService
    {
        Task<Response<PersonelDto>> CreateAsync(PersonelDto entity);
        Task<Response<PersonelDto>> GetByIdAsync(int id);
        Response<IEnumerable<PersonelDto>> GetAllAsync();


        Response<IEnumerable<PersonelDto>> FindByCondition(Expression<Func<Personel, bool>> expression);

        Task<Response<PersonelDto>> Update(PersonelDto entity);
        Task<Response<NoDataDto>> Delete(PersonelDto entity);
    }
}
