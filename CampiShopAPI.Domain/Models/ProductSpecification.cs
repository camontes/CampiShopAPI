using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CampiShopAPI.Domain.Models
{
    public class ProductSpecification
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int DetailSpecificationId { get; set; }

        [ForeignKey("DetailSpecificationId")]
        public virtual DetailSpecification DetailSpecification { get; set; }
    }
}
