using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ShoppingCartsController
            (
             IShoppingCartQueries queries,
             IMapper mapper
            )
        {
            _mapper = mapper;
            _queries = queries;
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
    }
}
