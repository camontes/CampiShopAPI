using CampiShopAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Repositories
{
    public interface IDetailSpecificationRepository
    {
        Task CreateDetailSpecificationAsync(DetailSpecification detailSpecification);
        Task UpdateDetailSpecificationAsync(DetailSpecification detailSpecification);
        Task DeleteDetailSpecificationAsync(DetailSpecification detailSpecification);
    }
}
