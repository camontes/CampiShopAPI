using CampiShopAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors.Interfaces
{
    public interface IDetailOrderBehavior
    {
        Task CreateDetailOrderAsync(int productId, int orderId, int amount, double total);
    }
}
