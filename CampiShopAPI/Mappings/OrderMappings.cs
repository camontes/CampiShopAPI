using AutoMapper;
using CampiShopAPI.Commands.Orders;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Mappings
{
    public class OrderMappings : Profile
    {
        public OrderMappings()
        {
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<OrderViewModel, Order>();
            CreateMap<UpdateRatingOrderCommand, Order>();
            CreateMap<UpdateStateOrderCommand, Order>();
        }
    }
}
