using AutoMapper;
using Business.Abstracts;
using Data.Abstracts;
using Entity.Models;
using Entity.ModelsDtos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWorkSecondDb _unitOfWorkSecond;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWorkSecondDb unitOfWorkSecond, IMapper mapper)
        {
            this._unitOfWorkSecond = unitOfWorkSecond;
            this._mapper = mapper;
        }

        public async Task<Response<CustomerDto>> CreateAsync(CustomerDto dto)
        {
            Customer entity = _mapper.Map<Customer>(dto);

            await _unitOfWorkSecond.CustomerRepository.CreateAsync(entity);
            await _unitOfWorkSecond.CommitAsync();
            var retModel = _mapper.Map<CustomerDto>(entity);
            return Response<CustomerDto>.Success(retModel, 200);
        }

        public async Task<Response<CustomerDto>> GetByIdAsync(int id)
        {
            var entity = await _unitOfWorkSecond.CustomerRepository.GetByIdAsync(id);
            if (entity == null)
            {
                var errors = new List<string>();
                errors.Add("ürün id'si bulunamadı");
                return Response<CustomerDto>.Fail(404, errors);
            }
            var retModel = _mapper.Map<CustomerDto>(entity);
            return Response<CustomerDto>.Success(retModel, 200);
        }


        public async Task<Response<IEnumerable<CustomerDto>>> GetAllAsync()
        {
            var entities = await _unitOfWorkSecond.CustomerRepository.GetAllAsync();
            var retModel = _mapper.Map<List<CustomerDto>>(entities);
            return Response<IEnumerable<CustomerDto>>.Success(retModel, 200);
        }

        public Response<IEnumerable<CustomerDto>> FindByCondition(Expression<Func<Customer, bool>> expression)
        {
            var list = _unitOfWorkSecond.CustomerRepository.FindByCondition(expression);
            var retModel = _mapper.Map<List<CustomerDto>>(list.ToListAsync());
            return Response<IEnumerable<CustomerDto>>.Success(retModel, 200);
        }


        public async Task<Response<CustomerDto>> Update(CustomerDto dto)
        {
            Customer entity = _mapper.Map<Customer>(dto);
            var isExistEntity = await _unitOfWorkSecond.CustomerRepository.GetByIdAsync(entity.Id);
            if (isExistEntity == null)
            {
                var errors = new List<string>();
                errors.Add("Güncellem yapılacak ürün id'si bulunamadı");
                return Response<CustomerDto>.Fail(404, errors);
            }

            //isExistEntity.FirstName = dto.UserName;
            //isExistEntity.LastName = dto.LastName;
            //isExistEntity.PhoneNumber = dto.PhoneNumber;
            //isExistEntity.Email = dto.Email;
            //isExistEntity.City = dto.City;
            //isExistEntity.LastUpdateUser = dto.LastUpdateUser;

            _unitOfWorkSecond.CustomerRepository.Update(isExistEntity);
            await _unitOfWorkSecond.CommitAsync();
            var retModel = _mapper.Map<CustomerDto>(entity);
            return Response<CustomerDto>.Success(retModel, 200);
        }


        public async Task<Response<NoDataDto>> Delete(CustomerDto dto)
        {
            Customer entity = _mapper.Map<Customer>(dto);
            var isExistEntity = await _unitOfWorkSecond.CustomerRepository.GetByIdAsync(entity.Id);
            if (isExistEntity == null)
            {
                var errors = new List<string>();
                errors.Add("Silinecek ürünün id'si bulunamadı");
                return Response<NoDataDto>.Fail(404, errors);
            }
            _unitOfWorkSecond.CustomerRepository.Delete(isExistEntity);
            await _unitOfWorkSecond.CommitAsync();
            return Response<NoDataDto>.Success(null, 200);

        }
    }
}
