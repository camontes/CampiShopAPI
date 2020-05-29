using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CampiShopAPI.Domain.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public double Total { get; set; }
        public int Rating { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Username { get; set; }

        [ForeignKey("Username")]
        public virtual User User { get; set; }
        public int StateOrderId { get; set; }

        [ForeignKey("StateOrderId")]
        public virtual StateOrder StateOrder { get; set; }
        public virtual IEnumerable<DetailOrder> DetailOrder { get; set; }

    }
}
