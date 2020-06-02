using CampiShopAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors.Interfaces
{
    public interface IDetailSpecificationBehavior
    {
        Task CreateDetailSpecificationAsync(DetailSpecification detailSpecification);
        Task UpdateDetailSpecificationAsync(DetailSpecification detailSpecification);
        Task DeleteDetailSpecificationAsync(DetailSpecification detailSpecification);
    }
}
