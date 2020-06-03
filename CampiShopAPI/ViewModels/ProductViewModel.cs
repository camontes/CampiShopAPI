using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string Color { get; set; }
        public string Photo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateddAt { get; set; }
    }
}
