using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CampiShopAPI.Domain.Models
{
    public class DetailSpecification
    {
        [Key]
        public int Id { get; set; }

        public int SpecificationId { get; set; }

        [ForeignKey("SpecificationId")]
        public virtual Specification Specification { get; set; }

        public virtual IEnumerable<ProductSpecification> ProductSpecification { get; set; }
    }
}
