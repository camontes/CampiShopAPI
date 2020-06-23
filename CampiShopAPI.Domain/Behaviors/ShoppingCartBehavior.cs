using CampiShopAPI.Domain.Behaviors.Interfaces;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors
{
    public class ShoppingCartBehavior : IShoppingCartBehavior
    {
        protected readonly IShoppingCartRepository _repository;

        public ShoppingCartBehavior(IShoppingCartRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateShoppingCartAsync(ShoppingCart shoppingCart, double price)
        {
            if (shoppingCart is null) throw new ArgumentNullException(nameof(shoppingCart));

            shoppingCart.Total = shoppingCart.Amount * price;

            await _repository.CreateShoppingCartAsync(shoppingCart);
        }

        public async Task UpdateShoppingCartAsync(ShoppingCart shoppingCart, double price)
        {
            if (shoppingCart is null) throw new ArgumentNullException(nameof(shoppingCart));

            shoppingCart.Total = shoppingCart.Amount * price;

            await _repository.UpdateShoppingCartAsync(shoppingCart);
        }
    }
}
