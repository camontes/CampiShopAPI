using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Commands.Specifications
{
    public class UpdateSpecificationCommand
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
