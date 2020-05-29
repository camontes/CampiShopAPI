using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CampiShopAPI.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string Color { get; set; }
        public string Photo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateddAt { get; set; }
        public virtual IEnumerable<DetailOrder> DetailOrder { get; set; }
        public virtual IEnumerable<ShoppingCart> ShoppingCart { get; set; }
        public virtual IEnumerable<ProductSpecification> ProductSpecification { get; set; }
    }
}
