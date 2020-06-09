using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.ViewModels
{
    public class ProductSpecificationViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int DetailSpecificationId { get; set; }
        public string ProductName { get; set; }
        public string DetailSpecificationName { get; set; }
        public string SpecificationName { get; set; }
    }
}
