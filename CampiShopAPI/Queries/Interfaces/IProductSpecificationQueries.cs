using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Queries.Interfaces
{
    public interface IProductSpecificationQueries
    {
        Task<List<ProductSpecificationViewModel>> FindAllAsync();
        Task<List<DetailSpecificationProductViewModel>> FindAllByProductIdAsync(int productId);
    }
}
