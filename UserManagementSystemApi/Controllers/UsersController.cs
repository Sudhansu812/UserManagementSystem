using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystemApi.CustomExceptions;
using UserManagementSystemApi.Models.Dto;
using UserManagementSystemApi.Services;

namespace UserManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _services;

        public UsersController(IUserServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable<UserReadDto>> GetAll()
        {
            List<UserReadDto> users;
            try
            {
                users = await _services.GetAll() as List<UserReadDto>;
            }
            catch (NoDataAvailableException ndae)
            {
                return null;
            }
            return users;
        }

        [HttpPost]
        public async Task<string> Create(UserCreateDto userCreateDto)
        {
            UserReadDto user = await _services.Create(userCreateDto);

            if (user == null)
            {
                return "User addition unsuccessfull";
            }
            return "User added successfully";
        }
    }
}
