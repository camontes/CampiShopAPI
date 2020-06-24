using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Commands.Orders
{
    public class CreateDetailOrderCommand
    {
        public CreateOrderCommand createOrderCommand { get; set; }
        public List<int> shoppingCarts { get; set; }
    }
}
