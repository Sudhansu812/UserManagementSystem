using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystemApi.Models;

namespace UserManagementSystemApi.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly UserContext _context;

        public UserRepo(UserContext context)
        {
            _context = context;
        }

        public void Create(UserModel giftCard)
        {
            if (giftCard == null)
            {
                throw new ArgumentNullException();
            }
            _context.Users.AddAsync(giftCard);
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            int rowsAffected = await _context.SaveChangesAsync();
            return (rowsAffected >= 0);
        }
    }
}
