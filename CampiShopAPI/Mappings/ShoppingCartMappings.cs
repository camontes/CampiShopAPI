using AutoMapper;
using CampiShopAPI.Commands.Products;
using CampiShopAPI.Commands.ShoppingCarts;
using CampiShopAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Mappings
{
    public class ShoppingCartMappings : Profile
    {
        public ShoppingCartMappings ()
        {
            CreateMap<CreateShoppingCartCommand, ShoppingCart>();
        }
    }
}
