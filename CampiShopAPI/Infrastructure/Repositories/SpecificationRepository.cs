using CampiShopAPI.Domain.Models;
using CampiShopAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Infrastructure.Repositories
{
    public class SpecificationRepository : ISpecificationRepository
    {
        protected readonly ApplicationDbContext _context;

        public SpecificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateSpecificationAsync(Specification specification)
        {
            _context.Specifications.Add(specification);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSpecificationAsync(Specification specification)
        {
            _context.Specifications.Update(specification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSpecificationAsync(Specification specification)
        {
            _context.Specifications.Remove(specification);
            await _context.SaveChangesAsync();
        }
    }
}
