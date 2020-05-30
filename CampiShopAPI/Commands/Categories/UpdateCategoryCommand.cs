using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Commands.Categories
{
    public class UpdateCategoryCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
