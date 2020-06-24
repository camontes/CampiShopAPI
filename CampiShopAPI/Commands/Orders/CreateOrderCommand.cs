using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Commands.Orders
{
    public class CreateOrderCommand
    {
        public string Address { get; set; }
        public double Total { get; set; }
        public string Username { get; set; }
    }
}
