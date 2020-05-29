using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CampiShopAPI.Domain.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Total { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public string Username { get; set; }

        [ForeignKey("Username")]
        public virtual User User { get; set; }
    }
}
