using CampiShopAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors.Interfaces
{
    public interface IProductBehavior
    {
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task UpdateAmountProductAsync(Product product, int amount);
        Task DeleteProductAsync(Product product);
    }
}
