using CampiShopAPI.Commands.DetailSpecifications;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Commands.Products
{
    public class CreateProductSpecificationCommand
    {
        public CreateProductCommand createProductCommand { get; set; }
        public List<int> detailSpecifications { get; set; }
    }
}
