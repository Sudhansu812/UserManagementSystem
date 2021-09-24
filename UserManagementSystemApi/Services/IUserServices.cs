using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystemApi.Models.Dto;

namespace UserManagementSystemApi.Services
{
    public interface IUserServices
    {
        Task<UserReadDto> Create(UserCreateDto userCreateDto);

        Task<IEnumerable<UserReadDto>> GetAll();
    }
}
