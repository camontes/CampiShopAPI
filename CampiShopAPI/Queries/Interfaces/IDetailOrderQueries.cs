using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Queries.Interfaces
{
    public interface IDetailOrderQueries
    {
        Task<List<DetailOrderViewModel>> FindAllAsync();
    }
}
