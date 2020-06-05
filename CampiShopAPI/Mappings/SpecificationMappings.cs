using AutoMapper;
using CampiShopAPI.Commands.Specifications;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Mappings
{
    public class SpecificationMappings : Profile
    {
        public SpecificationMappings()
        {
            CreateMap<CreateSpecificationCommand, Specification>();
            CreateMap<SpecificationViewModel, Specification>();
            CreateMap<UpdateSpecificationCommand, Specification>();
        }
    }
}
