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
    public class ProductSpecificationsController : ControllerBase
    {
        private readonly IProductSpecificationQueries _queries;
        private readonly IMapper _mapper;

        public ProductSpecificationsController
            (
                IProductSpecificationQueries  queries,
                IMapper mapper
            )
        {
            _queries = queries;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ProductSpecificationViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

    }
}
