using CampiShopAPI.Domain.Behaviors.Interfaces;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors
{
    public class DetailOrderBehavior : IDetailOrderBehavior
    {
        protected readonly IDetailOrderRepository _repository;

        public DetailOrderBehavior(IDetailOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateDetailOrderAsync(int productId, int orderId, int amount, double total)
        {
            DetailOrder detailOrder = new DetailOrder
            {
                ProductId = productId,
                Amount = amount,
                OrderId = orderId,
                Total = total
            };

            await _repository.CreateDetailOrderAsync(detailOrder);
        }
    }
}
