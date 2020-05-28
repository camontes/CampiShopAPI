using CampiShopAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors.Interfaces
{
    public interface IUserBehavior
    {
        Task CreateUserAsync(User user);
    }
}
