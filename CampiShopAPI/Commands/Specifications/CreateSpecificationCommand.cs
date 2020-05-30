using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Commands.Specifications
{
    public class CreateSpecificationCommand
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
