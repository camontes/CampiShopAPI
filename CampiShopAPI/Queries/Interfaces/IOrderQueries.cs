using CampiShopAPI.Domain.Models;
using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Queries.Interfaces
{
    public interface IOrderQueries
    {
        Task<List<OrderViewModel>> FindAllAsync();
        Task<OrderViewModel> FindByIdAsync(int id);
    }
}