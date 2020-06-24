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
    public class DetailOrderQueries : IDetailOrderQueries
    {
        protected readonly ApplicationDbContext _context;

        public DetailOrderQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DetailOrderViewModel>> FindAllAsync()
        {
            return await _context.DetailOrders.AsNoTracking()
                .Include(p => p.Product)
                .Select(d => new DetailOrderViewModel
                {
                    Id = d.Id,
                    Amount = d.Amount,
                    OrderId = d.OrderId,
                    ProductId = d.ProductId,
                    ProductName = d.Product.Name,
                    Total = d.Total
                })
                .ToListAsync();
        }
    }
}
