using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Queries.Interfaces
{
    public interface IDetailSpecificationQueries
    {
        Task<List<DetailSpecificationViewModel>> FindAllAsync();
        Task<DetailSpecificationViewModel> FindByIdAsync(int id);
        Task<List<DetailSpecificationViewModel>> FindBySpecificationId(int specificationId);
    }
}
