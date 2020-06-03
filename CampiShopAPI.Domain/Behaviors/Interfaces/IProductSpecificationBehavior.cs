using CampiShopAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors.Interfaces
{
    public interface IProductSpecificationBehavior
    {
        Task CreateProductSpecificationAsync(int productId, int detailspecificationId);
    }
}
