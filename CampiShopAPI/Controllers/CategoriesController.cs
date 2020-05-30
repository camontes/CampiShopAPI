using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampiShopAPI.Commands;
using CampiShopAPI.Commands.Categories;
using CampiShopAPI.Domain.Behaviors.Interfaces;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.Queries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampiShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryQueries _queries;

        private readonly ICategoryBehavior _behavior;

        private readonly IMapper _mapper;

        public CategoriesController
            (
                ICategoryQueries queries,
                ICategoryBehavior behavior,
                IMapper mapper
            )
        {
            _queries = queries;
            _behavior = behavior;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Category>> GetByIdAsync(int id)
        {
            var existingCategory =  await _queries.FindByIdAsync(id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            return existingCategory;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Category>> CreateCategoryAsync(CreateCategoryCommand createCategoryCommand)
        {
            var category = _mapper.Map<Category>(createCategoryCommand);
            await _behavior.CreateCategoryAsync(category);
            return category;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Category>> UpdateCategoryAsync(int id, UpdateCategoryCommand updateCategoryCommand)
        {
            var existingCategory = await _queries.FindByIdAsync(id);

            if (existingCategory == null) {
                return NotFound();
            }

            _mapper.Map(updateCategoryCommand, existingCategory);
            await _behavior.UpdateCategoryAsync(existingCategory);
            return existingCategory;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var existingCategory = await _queries.FindByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            await _behavior.DeleteCategoryAsync(existingCategory);
            return NoContent();
        }
    }
}
