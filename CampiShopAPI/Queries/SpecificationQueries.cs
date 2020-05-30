using CampiShopAPI.Infrastructure;
using CampiShopAPI.Queries.Interfaces;
using CampiShopAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Queries
{
    public class SpecificationQueries :  ISpecificationQueries
    {
        protected readonly ApplicationDbContext _context;

        public SpecificationQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SpecificationViewModel>> FindAllAsync()
        {
            return await _context.Specifications.AsNoTracking()
                .Include(s => s.Category)
                .Select(s => new SpecificationViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    CategoryId = s.CategoryId,
                    CategoryName = s.Category.Name
                })
                .ToListAsync();
        }

        public async Task<SpecificationViewModel> FindByIdAsync(int id)
        {
            return await _context.Specifications.AsNoTracking()
                .Include(s => s.Category)
                .Select(s => new SpecificationViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    CategoryId = s.CategoryId,
                    CategoryName = s.Category.Name
                })
                .FirstOrDefaultAsync(specification => specification.Id == id);
        }

        public async Task<List<SpecificationViewModel>> FindAllByCategoryIdAsync(int categoryId)
        {
            return await _context.Specifications.AsNoTracking()
                .Include(s => s.Category)
                .Select(s => new SpecificationViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    CategoryId = s.CategoryId,
                    CategoryName = s.Category.Name
                })
                .Where(specification => specification.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}
