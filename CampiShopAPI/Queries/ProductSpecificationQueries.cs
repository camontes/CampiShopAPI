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
                    ProductName = ps.Product.Name,
                    ProductPrice = ps.Product.Price,
                    ProductDescription = ps.Product.Description,
                    ProductAmount = ps.Product.Amount,
                    ProductColor = ps.Product.Color,
                    ProductPhoto = ps.Product.Photo,
                    ProductCreatedAt = ps.Product.CreatedAt,
                    ProductUpdatedAt = ps.Product.UpdatedAt,
                    CategoryId = ps.DetailSpecification.Specification.CategoryId,
                    CategoryName = ps.DetailSpecification.Specification.Category.Name,
                    DetailSpecificationId = ps.DetailSpecificationId,
                    DetailSpecificationName = ps.DetailSpecification.Name,
                    SpecificationName = ps.DetailSpecification.Specification.Name,
                    SpecificationId = ps.DetailSpecification.Specification.Id
                })
                .ToListAsync();
        }
        public async Task<List<DetailSpecificationProductViewModel>> FindAllByProductIdAsync(int productId)
        {
            return await _context.ProductSpecifications.AsNoTracking()
                .Include(p => p.Product)
                .Include(d => d.DetailSpecification)
                .Select(ps => new DetailSpecificationProductViewModel
                {
                    Id = ps.Id,
                    ProductId = ps.ProductId,
                    DetailSpecificationId = ps.DetailSpecificationId,
                    DetailSpecificationName = ps.DetailSpecification.Name,
                    SpecificationName = ps.DetailSpecification.Specification.Name,
                    SpecificationId = ps.DetailSpecification.Specification.Id
                })
                .Where(productSpecification => productSpecification.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductCategoryViewModel> FindByCategoryAsync(int productId)
        {
            return await _context.ProductSpecifications.AsNoTracking()
                .Include(d => d.DetailSpecification)
                .Select(ps => new ProductCategoryViewModel
                {
                    ProductId = ps.ProductId,
                    CategoryId = ps.DetailSpecification.Specification.CategoryId,
                    CategoryName = ps.DetailSpecification.Specification.Category.Name
                })
                .Where(productSpecification => productSpecification.ProductId == productId)
                .FirstOrDefaultAsync();
        }

        public async Task<ProductSpecificationViewModel> FindByProductIdAsync(int productId)
        {
            return await _context.ProductSpecifications.AsNoTracking()
                .Include(p => p.Product)
                .Include(d => d.DetailSpecification)
                .Select(ps => new ProductSpecificationViewModel
                {
                    Id = ps.Id,
                    ProductId = ps.ProductId,
                    ProductName = ps.Product.Name,
                    ProductPrice = ps.Product.Price,
                    ProductDescription = ps.Product.Description,
                    ProductAmount = ps.Product.Amount,
                    ProductColor = ps.Product.Color,
                    ProductPhoto = ps.Product.Photo,
                    ProductCreatedAt = ps.Product.CreatedAt,
                    ProductUpdatedAt = ps.Product.UpdatedAt,
                    CategoryId = ps.DetailSpecification.Specification.CategoryId,
                    CategoryName = ps.DetailSpecification.Specification.Category.Name,
                    DetailSpecificationId = ps.DetailSpecificationId,
                    DetailSpecificationName = ps.DetailSpecification.Name,
                    SpecificationName = ps.DetailSpecification.Specification.Name,
                    SpecificationId = ps.DetailSpecification.Specification.Id
                })
                .Where(ps => ps.ProductId == productId)
                .FirstOrDefaultAsync();
        }
    }
}
