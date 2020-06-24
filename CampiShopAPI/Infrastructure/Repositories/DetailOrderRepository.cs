using CampiShopAPI.Domain.Models;
using CampiShopAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Infrastructure.Repositories
{
    public class DetailOrderRepository : IDetailOrderRepository
    {
        protected readonly ApplicationDbContext _context;

        public DetailOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateDetailOrderAsync(DetailOrder detailOrder)
        {
            _context.DetailOrders.Add(detailOrder);
            await _context.SaveChangesAsync();
        }
    }
}
