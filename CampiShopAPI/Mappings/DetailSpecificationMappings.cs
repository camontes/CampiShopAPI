using AutoMapper;
using CampiShopAPI.Commands.DetailSpecifications;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Mappings
{
    public class DetailSpecificationMappings : Profile
    {
        public DetailSpecificationMappings()
        {
            CreateMap<CreateDetailSpecificationCommand, DetailSpecification>();
            CreateMap<DetailSpecificationViewModel, DetailSpecification>();
            CreateMap<UpdateDetailSpecificationCommand, DetailSpecificationViewModel>();
        }
    }
}
