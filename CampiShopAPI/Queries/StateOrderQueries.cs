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
    public class StateOrderQueries : IStateOrderQueries
    {
        protected readonly ApplicationDbContext _context;

        public StateOrderQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StateOrderViewModel>> FindAllAsync()
        {
            return await _context.StateOrders.AsNoTracking()
                 .Select(s => new StateOrderViewModel
                 {
                     Id = s.Id,
                     Name = s.Name
                 })
                .ToListAsync();
        }

        public async Task<StateOrderViewModel> FindByIdAsync(int id)
        {
            return await _context.StateOrders.AsNoTracking()
                .Select(s => new StateOrderViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .FirstOrDefaultAsync(stateOrder => stateOrder.Id == id);
        }
    }
}
