using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.ViewModels
{
    public class ProductDetailSpecificationViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductAmount { get; set; }
        public string ProductColor { get; set; }
        public string ProductPhoto { get; set; }
        public DateTime? ProductCreatedAt { get; set; }
        public DateTime? ProductUpdatedAt { get; set; }
        //Category
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<int> detailSpecificationsId { get; set; }
    }
}
