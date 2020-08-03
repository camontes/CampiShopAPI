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
        public async Task<ActionResult<IEnumerable<ProductDetailSpecificationViewModel>>> GetAllAsync()
        {
            List<ProductDetailSpecificationViewModel> productDetailSpecifications = new List<ProductDetailSpecificationViewModel>();
            List<ProductViewModel> products = await _productQueries.FindAllAsync();

            for (int i = 0; i < products.Count; i++)
            {
                ProductDetailSpecificationViewModel productSpecifications = new ProductDetailSpecificationViewModel();

                productSpecifications.ProductId = products[i].Id;
                productSpecifications.ProductName = products[i].Name;
                productSpecifications.ProductPrice = products[i].Price;
                productSpecifications.ProductDescription = products[i].Description;
                productSpecifications.ProductAmount = products[i].Amount;
                productSpecifications.ProductColor = products[i].Color;
                productSpecifications.ProductPhoto = products[i].Photo;
                productSpecifications.ProductCreatedAt = products[i].CreatedAt;
                productSpecifications.ProductUpdatedAt = products[i].UpdatedAt;

                var category = await _queries.FindByCategoryAsync(products[0].Id);
                productSpecifications.CategoryId = category.CategoryId;
                productSpecifications.CategoryName = category.CategoryName;

                //Get all specifications by product
                List<DetailSpecificationProductViewModel> productDetails = await _queries.FindAllByProductIdAsync(products[i].Id);
                //productSpecifications.Specifications = productDetails;
                productSpecifications.detailSpecificationsId = new List<int>();
                for (int j = 0; j < productDetails.Count; j++)
                {
                    productSpecifications.detailSpecificationsId.Add(productDetails[j].DetailSpecificationId);
                }

                productDetailSpecifications.Add(productSpecifications);
            }

            return productDetailSpecifications;

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

        [Route("GetProductCategory/{productId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductCategoryViewModel>> GetByCategoryAsync(int productId)
        {
            var existingProduct = await _productQueries.FindByIdAsync(productId);
            if (existingProduct == null)
            {
                return NotFound();
            }

            return await _queries.FindByCategoryAsync(productId);
        }
    }
}
