using CampiShopAPI.Domain.Models;
using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Queries.Interfaces
{
    public interface IProductQueries
    {
        Task<List<ProductViewModel>> FindAllAsync();
        Task<ProductViewModel> FindByIdAsync(int id);
    }
}
