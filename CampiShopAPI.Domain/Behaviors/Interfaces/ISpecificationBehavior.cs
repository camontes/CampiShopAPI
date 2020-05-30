using CampiShopAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors.Interfaces
{
    public interface ISpecificationBehavior
    {
        Task CreateSpecificationAsync(Specification specification);
        Task UpdateSpecificationAsync(Specification specification);
        Task DeleteSpecificationAsync(Specification specification);
    }
}
