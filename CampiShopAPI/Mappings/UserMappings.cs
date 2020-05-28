using AutoMapper;
using CampiShopAPI.Commands;
using CampiShopAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<CreateUserCommand, User>();

        }
    }
}
