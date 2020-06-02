using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.ViewModels
{
    public class DetailSpecificationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecificationId { get; set; }
        public string SpecificationName { get; set; }
    }
}
