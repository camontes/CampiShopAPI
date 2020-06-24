using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Queries.Interfaces
{
    public interface IShoppingCartQueries
    {
        Task<List<ShoppingCartViewModel>> FindAllAsync();
        Task<ShoppingCartViewModel> FindByIdAsync(int id);
        Task <List<ShoppingCartViewModel>> FindAllByUsernameAsync(string username);
    }
}
