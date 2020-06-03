using CampiShopAPI.Domain.Models;
using CampiShopAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Infrastructure.Repositories
{
    public class ProductSpecificationRepository : IProductSpecificationRepository
    {
        protected readonly ApplicationDbContext _context;

        public ProductSpecificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductSpecificationAsync(ProductSpecification productSpecification)
        {
            _context.ProductSpecifications.Add(productSpecification);
            await _context.SaveChangesAsync();
        }
    }
}
