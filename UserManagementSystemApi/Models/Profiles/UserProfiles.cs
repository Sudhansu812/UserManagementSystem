using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystemApi.Models.Dto;

namespace UserManagementSystemApi.Models.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<UserModel, UserReadDto>();
            CreateMap<UserCreateDto, UserModel>();
        }
    }
}
