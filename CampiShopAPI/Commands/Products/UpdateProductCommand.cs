using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Commands.Products
{
    public class UpdateProductCommand
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string Color { get; set; }
        public string Photo { get; set; }
    }
}
