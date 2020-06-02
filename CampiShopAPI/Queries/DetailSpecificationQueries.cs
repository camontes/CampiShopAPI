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
    public class DetailSpecificationQueries : IDetailSpecificationQueries
    {
        protected readonly ApplicationDbContext _context;

        public DetailSpecificationQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DetailSpecificationViewModel>> FindAllAsync()
        {
            return await _context.DetailSpecifications.AsNoTracking()
                .Include(d => d.Specification)
                .Select(d => new DetailSpecificationViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    SpecificationId = d.SpecificationId,
                    SpecificationName = d.Specification.Name
                })
                .ToListAsync();
        }

        public async Task<DetailSpecificationViewModel> FindByIdAsync(int id)
        {
            return await _context.DetailSpecifications.AsNoTracking()
                .Include(d => d.Specification)
                .Select(d => new DetailSpecificationViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    SpecificationId = d.SpecificationId,
                    SpecificationName = d.Specification.Name
                })
                .FirstOrDefaultAsync(detailSpecification => detailSpecification.Id == id);
        }

        public async Task<List<DetailSpecificationViewModel>> FindBySpecificationId(int specificationId)
        {
            return await _context.DetailSpecifications.AsNoTracking()
                .Include(d => d.Specification)
                .Select(d => new DetailSpecificationViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    SpecificationId = d.SpecificationId,
                    SpecificationName = d.Specification.Name
                })
                .Where(detailSpecification => detailSpecification.SpecificationId == specificationId)
                .ToListAsync();
        }
    }
}
