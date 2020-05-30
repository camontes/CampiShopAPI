using CampiShopAPI.Domain.Models;
using CampiShopAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Queries.Interfaces
{
    public class CategoryQueries : ICategoryQueries
    {
        protected readonly ApplicationDbContext _context;

        public CategoryQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> FindAllAsync()
        {
            return await _context.Categories.AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.AsNoTracking()
                .FirstOrDefaultAsync(category => category.Id == id);
        }
    }
}
