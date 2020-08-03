using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampiShopAPI.Commands.Products;
using CampiShopAPI.Commands.ShoppingCarts;
using CampiShopAPI.Domain.Behaviors.Interfaces;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.Queries.Interfaces;
using CampiShopAPI.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampiShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductQueries _queries;
        private readonly IProductSpecificationQueries _productSpecificationsqueries;
        private readonly IUserQueries _userQueries;
        private readonly IShoppingCartQueries _shoppingCartQueries;
        private readonly IDetailSpecificationQueries _detailSpecificationQueries;
        private readonly IProductBehavior _behavior;
        private readonly IShoppingCartBehavior _shoppingCartBehavior;
        private readonly IProductSpecificationBehavior _productSpecificationbehavior;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ProductsController
           (
                IProductQueries queries,
                IProductSpecificationQueries productSpecificationQueries,
                IProductBehavior behavior,
                IProductSpecificationBehavior productSpecificationBehavior,
                IShoppingCartQueries shoppingCartQueries,
                IDetailSpecificationQueries detailSpecificationQueries,
                IShoppingCartBehavior shoppingCartBehavior,
                IUserQueries userQueries,
                IMapper mapper,
                IWebHostEnvironment environment
           )
        {
            _queries = queries;
            _mapper = mapper;
            _behavior = behavior;
            _userQueries = userQueries;
            _productSpecificationbehavior = productSpecificationBehavior;
            _detailSpecificationQueries = detailSpecificationQueries;
            _shoppingCartBehavior = shoppingCartBehavior;
            _shoppingCartQueries = shoppingCartQueries;
            _env = environment;
            _productSpecificationsqueries = productSpecificationQueries;

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
        public async Task<ActionResult<ProductDetailSpecificationViewModel>> CreateProductAsync(CreateProductSpecificationCommand createProductSpecificationCommand)
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

            var productSpecificationViewModel = await _productSpecificationsqueries.FindByProductIdAsync(product.Id);
            var productDetailSpecifications = _mapper.Map<ProductDetailSpecificationViewModel>(productSpecificationViewModel);
            productDetailSpecifications.detailSpecificationsId = createProductSpecificationCommand.detailSpecifications;

            return productDetailSpecifications;
        }

        [Route("SavePhoto")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<string>> SaveProductPhotoAsync(IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                var imagePath = @"/Images/Products/";
                var uploadPath = "C:\\Users\\juanCarlos\\source\\repos\\CampiShopWeb\\public" + imagePath;

                //Create Directory
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                //Create Uniq file name
                var uniqFileName = Guid.NewGuid().ToString();
                var filename = Path.GetFileName(uniqFileName + "." + photo.FileName.Split(".")[1].ToLower());
                string fullpath = uploadPath + filename;

                //imagePath = imagePath + @"/";
                var filePath = Path.Combine(imagePath, filename);

                using (FileStream fileStream = new FileStream(fullpath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                return filePath;
            }

            return "";

        }

        [Route("AddProductShoppingCart")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<ShoppingCartViewModel>> AddProductShoppingCartAsync(ShoppingCartCommand shoppingCartCommand)
        {
            var existingProduct = await _queries.FindByIdAsync(shoppingCartCommand.ProductId);
            var existingUser = await _userQueries.FindByUsernameAsync(shoppingCartCommand.Username);

            if (existingProduct == null || existingUser == null) return NotFound();

            var existingProductInShoppingCart = await _shoppingCartQueries.FindByIdUsernameAsync(shoppingCartCommand.ProductId, shoppingCartCommand.Username);

            if (existingProductInShoppingCart != null)
            {
                return Conflict();
            }

            var shoppingCart = _mapper.Map<ShoppingCart>(shoppingCartCommand);

            await _shoppingCartBehavior.CreateShoppingCartAsync(shoppingCart, existingProduct.Price);

            var shoppingCartViewModel = await _shoppingCartQueries.FindByIdAsync(shoppingCart.Id);

            return shoppingCartViewModel;

        }

        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductViewModel>> UpdateProductAsync(int id, UpdateProductCommand updateProductCommand)
        {
            var existingProductViewModel = await _queries.FindByIdAsync(id);

            if (existingProductViewModel == null)
            {
                return NotFound();
            }

            Product product = _mapper.Map<Product>(existingProductViewModel);
            _mapper.Map(updateProductCommand, product);
            await _behavior.UpdateProductAsync(product);

            var productViewModel = await _queries.FindByIdAsync(product.Id);

            return productViewModel;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var existingProduct = await _queries.FindByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            var product = _mapper.Map<Product>(existingProduct);
            await _behavior.DeleteProductAsync(product);

            return NoContent();
        }
    }
}
