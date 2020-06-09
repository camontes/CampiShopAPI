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
    public class ProductSpecificationQueries : IProductSpecificationQueries
    {
        protected readonly ApplicationDbContext _context;

        public ProductSpecificationQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductSpecificationViewModel>> FindAllAsync()
        {
            return await _context.ProductSpecifications.AsNoTracking()
                .Include(p => p.Product)
                .Include(d => d.DetailSpecification)
                .Select(ps => new ProductSpecificationViewModel
                {
                    Id = ps.Id,
                    ProductId = ps.ProductId,
                    DetailSpecificationId = ps.DetailSpecificationId,
                    ProductName = ps.Product.Name,
                    DetailSpecificationName = ps.DetailSpecification.Name,
                    SpecificationName = ps.DetailSpecification.Specification.Name
                })
                .ToListAsync();
        }
    }
}
