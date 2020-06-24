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
    public class OrderQueries : IOrderQueries
    {
        protected readonly ApplicationDbContext _context;

        public OrderQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderViewModel>> FindAllAsync()
        {
            return await _context.Orders.AsNoTracking()
                .Include(u => u.User)
                .Include(s => s.StateOrder)
                .Select(o => new OrderViewModel
                {
                    Id = o.Id,
                    Address = o.Address,
                    Total = o.Total,
                    Rating = o.Rating,
                    CreatedAt = o.CreatedAt,
                    Username = o.Username,
                    StateOrderId = o.StateOrderId,
                    StateOrderName = o.StateOrder.Name
                })
                .ToListAsync();
        }

        public async Task<OrderViewModel> FindByIdAsync(int id)
        {
            return await _context.Orders.AsNoTracking()
                .Include(u => u.User)
                .Include(s => s.StateOrder)
                .Select(o => new OrderViewModel
                {
                    Id = o.Id,
                    Address = o.Address,
                    Total = o.Total,
                    Rating = o.Rating,
                    CreatedAt = o.CreatedAt,
                    Username = o.Username,
                    StateOrderId = o.StateOrderId,
                    StateOrderName = o.StateOrder.Name
                })
                .FirstOrDefaultAsync(order => order.Id == id);
        }
    }
}
