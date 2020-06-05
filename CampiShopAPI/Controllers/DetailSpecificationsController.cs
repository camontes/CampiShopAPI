using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampiShopAPI.Commands.DetailSpecifications;
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
    public class DetailSpecificationsController : ControllerBase
    {
        private readonly IDetailSpecificationQueries _queries;
        private readonly ISpecificationQueries _specificationQueries;
        private readonly IDetailSpecificationBehavior _behavior;
        private readonly IMapper _mapper;

        public DetailSpecificationsController
            (
                IDetailSpecificationQueries queries,
                IMapper mapper,
                IDetailSpecificationBehavior behavior,
                ISpecificationQueries specificationQueries
            )
        {
            _queries = queries;
            _mapper = mapper;
            _behavior = behavior;
            _specificationQueries = specificationQueries;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<DetailSpecificationViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DetailSpecificationViewModel>> GetByIdAsync(int id)
        {
            var existingDetailSpecification = await _queries.FindByIdAsync(id);

            if (existingDetailSpecification == null)
            {
                return NotFound();
            }

            return existingDetailSpecification;
        }

        [Route("BySpecification/{specificationId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<DetailSpecificationViewModel>>> GetBySpecificationIdAsync(int specificationId)
        {
            return await _queries.FindBySpecificationId(specificationId);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DetailSpecificationViewModel>> CreateDetailSpecificationAsync(CreateDetailSpecificationCommand createDetailSpecificationCommand)
        {
            var existingSpecification = await _specificationQueries.FindByIdAsync(createDetailSpecificationCommand.SpecificationId);

            if (existingSpecification == null)
            {
                return NotFound();
            }
            var detailSpecification = _mapper.Map<DetailSpecification>(createDetailSpecificationCommand);

            await _behavior.CreateDetailSpecificationAsync(detailSpecification);

            var detailSpecificationViewModel = await _queries.FindByIdAsync(detailSpecification.Id);

            return detailSpecificationViewModel;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DetailSpecificationViewModel>> UpdateDetailSpecificationAsync(int id, UpdateDetailSpecificationCommand updateDetailSpecificationCommand)
        {
            var existingDetailSpecificationViewModel = await _queries.FindByIdAsync(id);
            var existingSpecification = await _specificationQueries.FindByIdAsync(updateDetailSpecificationCommand.SpecificationId);

            if (existingDetailSpecificationViewModel == null || existingSpecification == null)
            {
                return NotFound();
            }

            var detailSpecification = _mapper.Map<DetailSpecification>(existingDetailSpecificationViewModel);

            _mapper.Map(updateDetailSpecificationCommand, detailSpecification);

            await _behavior.UpdateDetailSpecificationAsync(detailSpecification);

            var detailSpecificationViewModel = await _queries.FindByIdAsync(detailSpecification.Id);

            return detailSpecificationViewModel;
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteDetailSpecificationAsync(int id)
        {
            var existingDetailSpecification = await _queries.FindByIdAsync(id);
            if (existingDetailSpecification == null)
            {
                return NotFound();
            }

            var detailSpecification = _mapper.Map<DetailSpecification>(existingDetailSpecification);
            await _behavior.DeleteDetailSpecificationAsync(detailSpecification);

            return NoContent();
        }
    }
}
