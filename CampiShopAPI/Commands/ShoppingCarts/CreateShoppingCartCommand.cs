using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Commands.ShoppingCarts
{
    public class CreateShoppingCartCommand
    {
        public int Amount { get; set; }
        public int ProductId { get; set; }
        public string Username { get; set; }
    }
}
