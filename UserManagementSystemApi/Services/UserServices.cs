using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystemApi.CustomExceptions;
using UserManagementSystemApi.Models;
using UserManagementSystemApi.Models.Dto;
using UserManagementSystemApi.Repository;

namespace UserManagementSystemApi.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UserServices(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserReadDto> Create(UserCreateDto userCreateDto)
        {
            UserModel user = _mapper.Map<UserModel>(userCreateDto);

            try
            {
                _repository.Create(user);
            }
            catch
            {
                return null;
            }

            if (await _repository.SaveChanges() == false)
            {
                return null;
            }

            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<IEnumerable<UserReadDto>> GetAll()
        {
            List<UserModel> users = (await _repository.GetAll()).ToList();

            if (users.Count == 0)
            {
                throw new NoDataAvailableException("No Data in the Database");
            }

            return _mapper.Map<IEnumerable<UserReadDto>>(users);
        }
    }
}
