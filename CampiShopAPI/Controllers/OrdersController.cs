using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampiShopAPI.Commands.Orders;
using CampiShopAPI.Domain.Behaviors.Interfaces;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.Queries.Interfaces;
using CampiShopAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CampiShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderQueries _queries;

        private readonly IOrderBehavior _behavior;

        private readonly IShoppingCartQueries _shoppingCartQueries;

        private readonly IUserQueries _userQueries;

        private readonly IStateOrderQueries _stateOrderQueries;

        private readonly IDetailOrderBehavior _detailOrderBehavior;

        private readonly IMapper _mapper;

        public OrdersController
            (
                IOrderQueries queries,
                IShoppingCartQueries shoppingCartQueries,
                IUserQueries userQueries,
                IStateOrderQueries stateOrderQueries,
                IOrderBehavior behavior,
                IDetailOrderBehavior detailOrderBehavior,
                IMapper mapper
            )
        {
            _queries = queries;
            _shoppingCartQueries = shoppingCartQueries;
            _userQueries = userQueries;
            _stateOrderQueries = stateOrderQueries;
            _detailOrderBehavior = detailOrderBehavior;
            _behavior = behavior;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<OrderViewModel>> GetByIdAsync(int id)
        {
            var exsitingOrder = await _queries.FindByIdAsync(id);

            if (exsitingOrder == null)
            {
                return NotFound();
            }

            return exsitingOrder;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<OrderViewModel>> CreateOrderAsync(CreateDetailOrderCommand createDetailOrderCommand)
        {
            if (createDetailOrderCommand.shoppingCarts.Count == 0)
            {
                return BadRequest();
            }

            // Validation of resources

            for (int i = 0; i < createDetailOrderCommand.shoppingCarts.Count; i++)
            {
                var shoppingCartId = createDetailOrderCommand.shoppingCarts[i];

                var existingShoppingCart = await _shoppingCartQueries.FindByIdAsync(shoppingCartId);

                if (existingShoppingCart == null)
                {
                    return NotFound("One or more of the shopping carts doesn't exist");
                }
            }

            var existingUser = await _userQueries.FindByUsernameAsync(createDetailOrderCommand.createOrderCommand.Username);

            if (existingUser == null) return NotFound("The user doesn't exist");

            // Creating the order

            var order = _mapper.Map<Order>(createDetailOrderCommand.createOrderCommand);

            await _behavior.CreateOrderAsync(order);

            // Creating the detailOrders

            for (int i = 0; i < createDetailOrderCommand.shoppingCarts.Count; i++)
            {
                var shoppingCartId = createDetailOrderCommand.shoppingCarts[i];

                var shoppingCart = await _shoppingCartQueries.FindByIdAsync(shoppingCartId);

                var productId = shoppingCart.ProductId;
                var orderId = order.Id;
                var amount = shoppingCart.Amount;
                var total = shoppingCart.Total;

                await _detailOrderBehavior.CreateDetailOrderAsync(productId, orderId, amount, total);
            }

            var orderViewModel = await _queries.FindByIdAsync(order.Id);

            return orderViewModel;
        }

        [Route("UpdateRatingOrder/{id}")]
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<OrderViewModel>> UpdateRatingOrderAsync(int id, UpdateRatingOrderCommand updateRatingOrderCommand)
        {
            var existingOrderViewModel = await _queries.FindByIdAsync(id);

            if (existingOrderViewModel == null)
            {
                return NotFound();
            }

            Order order = _mapper.Map<Order>(existingOrderViewModel);
            _mapper.Map(updateRatingOrderCommand, order);
            await _behavior.UpdateOrderAsync(order);

            var orderViewModel = await _queries.FindByIdAsync(order.Id);

            return orderViewModel;
        }

        [Route("UpdateStateOrder/{id}")]
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<OrderViewModel>> UpdateRatingOrderAsync(int id, UpdateStateOrderCommand updateStateOrderCommand)
        {
            var existingOrderViewModel = await _queries.FindByIdAsync(id);
            var existingStateOrder = await _stateOrderQueries.FindByIdAsync(updateStateOrderCommand.StateOrderId);

            if (existingOrderViewModel == null || existingStateOrder == null)
            {
                return NotFound();
            }

            Order order = _mapper.Map<Order>(existingOrderViewModel);
            _mapper.Map(updateStateOrderCommand, order);
            await _behavior.UpdateOrderAsync(order);

            var orderViewModel = await _queries.FindByIdAsync(order.Id);

            return orderViewModel;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var existingOrder = await _queries.FindByIdAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            var order = _mapper.Map<Order>(existingOrder);
            await _behavior.DeleteOrderAsync(order);

            return NoContent();
        }
    }
}
