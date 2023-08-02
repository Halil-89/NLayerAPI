using AutoMapper;
using Business.Abstracts;
using Data.Abstracts;
using Entity.Models;
using Entity.ModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PersonelService : IPersonelService
    {
        private readonly IUnitOfWorkContextApi _unitOfWorkContextApi;
        private readonly IMapper _mapper;

        public PersonelService(IUnitOfWorkContextApi unitOfWorkContextApi, IMapper mapper)
        {
            _unitOfWorkContextApi = unitOfWorkContextApi;
            _mapper = mapper;
        }

        


        public Task<Response<PersonelDto>> CreateAsync(PersonelDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> Delete(PersonelDto entity)
        {
            throw new NotImplementedException();
        }

        public Response<IEnumerable<PersonelDto>> FindByCondition(Expression<Func<Personel, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public  Response<IEnumerable<PersonelDto>> GetAllAsync()
        {
            var entities =  _unitOfWorkContextApi.PersonelRepository.GetAllAsync();
            var retModel = _mapper.Map<List<PersonelDto>>(entities);
            return Response<IEnumerable<PersonelDto>>.Success(retModel, 200);
        }

        public Task<Response<PersonelDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PersonelDto>> Update(PersonelDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
