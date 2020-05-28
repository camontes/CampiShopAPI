using CampiShopAPI.Domain.Models;
using CampiShopAPI.Infrastructure;
using CampiShopAPI.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Queries
{
    public class UserQueries : IUserQueries
    {
        protected readonly ApplicationDbContext _context;

        public UserQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> FindAllAsync()
        {
            return await _context.Users.AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(user => user.Username == username);
        }
    }
}
