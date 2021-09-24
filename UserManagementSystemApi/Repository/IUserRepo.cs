using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystemApi.Models;

namespace UserManagementSystemApi.Repository
{
    public interface IUserRepo
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<UserModel>> GetAll();

        void Create(UserModel user);
    }
}
