using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Queries.Interfaces
{
    public interface ISpecificationQueries
    {
        Task<List<SpecificationViewModel>> FindAllAsync();
        Task<SpecificationViewModel> FindByIdAsync(int id);
        Task<List<SpecificationViewModel>> FindAllByCategoryIdAsync(int categoryId);
    }
}
