using CampiShopAPI.Domain.Models;
using CampiShopAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
