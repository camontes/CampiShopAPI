using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampiShopAPI.Commands.Products;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductQueries _queries;
        private readonly IDetailSpecificationQueries _detailSpecificationQueries;
        private readonly IProductBehavior _behavior;
        private readonly IProductSpecificationBehavior _productSpecificationbehavior;
        private readonly IMapper _mapper;

        public ProductsController
           (
                IProductQueries queries,
                IProductBehavior behavior,
                IProductSpecificationBehavior productSpecificationBehavior,
                IDetailSpecificationQueries detailSpecificationQueries,
                IMapper mapper
           )
        {
            _queries = queries;
            _mapper = mapper;
            _behavior = behavior;
            _productSpecificationbehavior = productSpecificationBehavior;
            _detailSpecificationQueries = detailSpecificationQueries;

        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductViewModel>> GetByIdAsync(int id)
        {
            var existingProduct = await _queries.FindByIdAsync(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            return existingProduct;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductViewModel>> CreateProductAsync(CreateProductSpecificationCommand createProductSpecificationCommand)
        {
            if (createProductSpecificationCommand.detailSpecifications.Count == 0)
            {
                return BadRequest();
            }

            // Validate if all the DetailSpecifications exist

            for (int i = 0; i < createProductSpecificationCommand.detailSpecifications.Count; i++)
            {
                var detailSpecificationId = createProductSpecificationCommand.detailSpecifications[i];

                var existingDetailSpecificationId = await _detailSpecificationQueries.FindByIdAsync(detailSpecificationId);

                if (existingDetailSpecificationId == null)
                {
                    return NotFound();
                }

            }

            var product = _mapper.Map<Product>(createProductSpecificationCommand.createProductCommand);

            await _behavior.CreateProductAsync(product);

            // If they exist then create resource in DB

            for (int i = 0; i< createProductSpecificationCommand.detailSpecifications.Count; i++)
            {
                var detailSpecificationId = createProductSpecificationCommand.detailSpecifications[i];
                var productId = product.Id;

                await _productSpecificationbehavior.CreateProductSpecificationAsync(productId, detailSpecificationId);
            }

            var productViewModel = await _queries.FindByIdAsync(product.Id);

            return productViewModel;
        }
    }
}
