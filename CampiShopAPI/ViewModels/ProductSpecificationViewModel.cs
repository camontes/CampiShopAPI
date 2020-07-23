using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.ViewModels
{
    public class ProductSpecificationViewModel
    {
        public int Id { get; set; }
        //Product
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
        //Detail Specification
        public int DetailSpecificationId { get; set; }
        public string DetailSpecificationName { get; set; }
        //Specification
        public int SpecificationId { get; set; }
        public string SpecificationName { get; set; }
    }
}
