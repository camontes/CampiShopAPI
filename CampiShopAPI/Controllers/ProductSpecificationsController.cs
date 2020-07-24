using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampiShopAPI.Queries.Interfaces;
using CampiShopAPI.Utilities;
using CampiShopAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampiShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSpecificationsController : ControllerBase
    {
        private readonly IProductSpecificationQueries _queries;
        private readonly IProductQueries _productQueries;
        private readonly IMapper _mapper;

        public ProductSpecificationsController
            (
                IProductSpecificationQueries  queries,
                IProductQueries productQueries,
                IMapper mapper
            )
        {
            _queries = queries;
            _mapper = mapper;
            _productQueries = productQueries;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ProductSpecificationViewModel>>> GetAllAsync()
        {
            //List<ProductSpecificationViewModel> productSpecifications = await _queries.FindAllAsync();

           // List<ProductSpecificationViewModel> products = productSpecifications.Distinct(new ProductIdComparer()).ToList();

            return await _queries.FindAllAsync(); ;
        }

        [Route("GetByProductId/{productId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<DetailSpecificationProductViewModel>>> GetAllByProductIdAsync(int productId)
        {
            var existingProduct = await _productQueries.FindByIdAsync(productId);
            if (existingProduct == null)
            {
                return NotFound();
            }

            return await _queries.FindAllByProductIdAsync(productId);
        }

    }
}
