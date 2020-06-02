using CampiShopAPI.Domain.Models;
using CampiShopAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Infrastructure.Repositories
{
    public class DetailSpecificationRepository : IDetailSpecificationRepository
    {
        protected readonly ApplicationDbContext _context;

        public DetailSpecificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateDetailSpecificationAsync(DetailSpecification detailSpecification)
        {
            _context.DetailSpecifications.Add(detailSpecification);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDetailSpecificationAsync(DetailSpecification detailSpecification)
        {
            _context.DetailSpecifications.Update(detailSpecification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDetailSpecificationAsync(DetailSpecification detailSpecification)
        {
            _context.DetailSpecifications.Remove(detailSpecification);
            await _context.SaveChangesAsync();
        }
    }
}
