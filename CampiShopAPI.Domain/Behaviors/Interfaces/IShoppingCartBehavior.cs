using CampiShopAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors.Interfaces
{
    public interface IShoppingCartBehavior
    {
        Task CreateShoppingCartAsync(ShoppingCart shoppingCart, double price);
        Task UpdateShoppingCartAsync(ShoppingCart shoppingCart, double price);
        Task DeleteShoppingCartAsync(ShoppingCart shoppingCart);
    }
}
