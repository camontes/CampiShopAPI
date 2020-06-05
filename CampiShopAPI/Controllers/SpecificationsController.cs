using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampiShopAPI.Commands.Specifications;
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
    public class SpecificationsController : ControllerBase
    {
        private readonly ISpecificationQueries _queries;
        private readonly ICategoryQueries _categoryQueries;

        private readonly ISpecificationBehavior _behavior;

        private readonly IMapper _mapper;

        public SpecificationsController 
            (
                ISpecificationQueries queries,
                ISpecificationBehavior behavior,
                ICategoryQueries categoryQueries,
                IMapper mapper
            )
        {
            _queries = queries;
            _mapper = mapper;
            _behavior = behavior;
            _categoryQueries = categoryQueries;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<SpecificationViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SpecificationViewModel>> GetByIdAsync(int id)
        {
            var existingSpecification = await _queries.FindByIdAsync(id);

            if (existingSpecification == null)
            {
                return NotFound();
            }

            return existingSpecification;
        }

        [Route("ByCategory/{categoryId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<SpecificationViewModel>>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await _queries.FindAllByCategoryIdAsync(categoryId);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SpecificationViewModel>> CreateSpecificationAsync(CreateSpecificationCommand createSpecificationCommand)
        {
            var existingCategory = await _categoryQueries.FindByIdAsync(createSpecificationCommand.CategoryId);

            if (existingCategory == null) {
                return NotFound();
            }

            var specification = _mapper.Map<Specification>(createSpecificationCommand);

            await _behavior.CreateSpecificationAsync(specification);

            var specificationViewModel = await _queries.FindByIdAsync(specification.Id);

            return specificationViewModel;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SpecificationViewModel>> UpdateSpecificationAsync(int id, UpdateSpecificationCommand updateSpecificationCommand)
        {
            var existingSpecificationViewModel = await _queries.FindByIdAsync(id);
            var existingCategory = await _categoryQueries.FindByIdAsync(updateSpecificationCommand.CategoryId);

            if (existingSpecificationViewModel == null || existingCategory == null)
            {
                return NotFound();
            }

            var specification = _mapper.Map<Specification>(existingSpecificationViewModel);

            _mapper.Map(updateSpecificationCommand, specification);

            await _behavior.UpdateSpecificationAsync(specification);

            var specificationViewModel = await _queries.FindByIdAsync(specification.Id);

            return specificationViewModel;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSpecificationAsync(int id)
        {
            var existingSpecification = await _queries.FindByIdAsync(id);
            if (existingSpecification == null)
            {
                return NotFound();
            }

            var specification = _mapper.Map<Specification>(existingSpecification);
            await _behavior.DeleteSpecificationAsync(specification);

            return NoContent();
        }
    }
}
