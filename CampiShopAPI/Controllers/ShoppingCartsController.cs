using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampiShopAPI.Commands.ShoppingCarts;
using CampiShopAPI.Domain.Behaviors.Interfaces;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.Queries.Interfaces;
using CampiShopAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampiShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IShoppingCartQueries _queries;
        private readonly IUserQueries _userQueries;
        private readonly IShoppingCartBehavior _behavior;
        private readonly IMapper _mapper;

        public ShoppingCartsController
            (
             IShoppingCartQueries queries,
             IShoppingCartBehavior behavior,
             IUserQueries userQueries,
             IMapper mapper
            )
        {
            _mapper = mapper;
            _queries = queries;
            _userQueries = userQueries;
            _behavior = behavior;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ShoppingCartViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ShoppingCartViewModel>> GetByIdAsync(int id)
        {
            var existingShopingCart = await _queries.FindByIdAsync(id);

            if (existingShopingCart == null)
            {
                return NotFound();
            }

            return existingShopingCart;
        }

        [Route("GetByUsername/{username}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<ShoppingCartViewModel>>> GetByUsernameAsync(string username)
        {
            var existingUser = await _userQueries.FindByUsernameAsync(username);

            if (existingUser == null)
            {
                return NotFound();
            }

            return await _queries.FindAllByUsernameAsync(username);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ShoppingCartViewModel>> UpdateShoppingCartAsync(int id, UpdateShoppingCartCommand updateShoppingCartCommand)
        {
            var existingShoppingCartViewModel = await _queries.FindByIdAsync(id);

            if (existingShoppingCartViewModel == null)
            {
                return NotFound();
            }

            ShoppingCart shoppingCart = _mapper.Map<ShoppingCart>(existingShoppingCartViewModel);
            _mapper.Map(updateShoppingCartCommand, shoppingCart);
            await _behavior.UpdateShoppingCartAsync(shoppingCart, existingShoppingCartViewModel.PriceProduct);

            var shoppingCartViewModel = await _queries.FindByIdAsync(id);

            return shoppingCartViewModel;
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteShoppingCartAsync(int id)
        {
            var existingShoppingCart = await _queries.FindByIdAsync(id);
            if (existingShoppingCart == null)
            {
                return NotFound();
            }

            var shoppingCart = _mapper.Map<ShoppingCart>(existingShoppingCart);
            await _behavior.DeleteShoppingCartAsync(shoppingCart);

            return NoContent();
        }
    }
}
