using CampiShopAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Queries.Interfaces
{
    public interface ICategoryQueries
    {
        Task<List<Category>> FindAllAsync();
        Task<Category> FindByIdAsync(int id);
    }
}
