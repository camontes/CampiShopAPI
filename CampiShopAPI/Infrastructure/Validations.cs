using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Infrastructure
{
    public static class Validations
    {
        public static bool IsPossibleToBuy(ProductViewModel product, ShoppingCartViewModel shoppingCart)
        {
            return shoppingCart.Amount < product.Amount;
        }
    }
}
