using CampiShopAPI.Domain.Behaviors.Interfaces;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors
{
    public class OrderBehavior : IOrderBehavior
    {
        protected readonly IOrderRepository _repository;

        public OrderBehavior(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateOrderAsync(Order order)
        {
            if (order is null) throw new ArgumentNullException(nameof(order));

            order.CreatedAt = DateTime.Now;
            order.StateOrderId = 1;
            order.Rating = 0;

            await _repository.CreateOrderAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            if (order is null) throw new ArgumentNullException(nameof(order));

            await _repository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(Order order)
        {
            if (order is null) throw new ArgumentNullException(nameof(order));

            await _repository.DeleteOrderAsync(order);
        }
    }
}
