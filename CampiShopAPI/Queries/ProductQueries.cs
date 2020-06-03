using CampiShopAPI.Domain.Models;
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
    public class ProductQueries : IProductQueries
    {
        protected readonly ApplicationDbContext _context;

        public ProductQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> FindAllAsync()
        {
            return await _context.Products.AsNoTracking()
                 .Select(p => new ProductViewModel
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Price = p.Price,
                     Description = p.Description,
                     Amount = p.Amount,
                     Color = p.Color,
                     Photo = p.Photo,
                     CreatedAt = p.CreatedAt,
                     UpdateddAt = p.UpdateddAt
                 })
                .ToListAsync();
        }

        public async Task<ProductViewModel> FindByIdAsync(int id)
        {
            return await _context.Products.AsNoTracking()
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    Amount = p.Amount,
                    Color = p.Color,
                    Photo = p.Photo,
                    CreatedAt = p.CreatedAt,
                    UpdateddAt = p.UpdateddAt
                })
                .FirstOrDefaultAsync(product => product.Id == id);
        }
    }
}
