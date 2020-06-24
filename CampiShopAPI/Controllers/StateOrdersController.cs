using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampiShopAPI.Queries.Interfaces;
using CampiShopAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CampiShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateOrdersController : ControllerBase
    {
        private readonly IStateOrderQueries _queries;

        public StateOrdersController
            (
                IStateOrderQueries queries
            )
        {
            _queries = queries;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<StateOrderViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<StateOrderViewModel>> GetByIdAsync(int id)
        {
            var existingStateOrderViewModel = await _queries.FindByIdAsync(id);

            if (existingStateOrderViewModel == null)
            {
                return NotFound();
            }

            return existingStateOrderViewModel;
        }
    }
}
