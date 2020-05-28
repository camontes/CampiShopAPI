using CampiShopAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Queries.Interfaces
{
    public interface IUserQueries
    {
        Task<List<User>> FindAllAsync();
        Task<User> FindByUsernameAsync(string username);
    }
}
