using AutoMapper;
using CampiShopAPI.Commands.Products;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Mappings
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<ProductSpecificationViewModel, ProductDetailSpecificationViewModel>();
        }
    }
}
