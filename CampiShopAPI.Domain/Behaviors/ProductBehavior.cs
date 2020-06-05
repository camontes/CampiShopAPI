using CampiShopAPI.Domain.Behaviors.Interfaces;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors
{
    public class ProductBehavior : IProductBehavior
    {
        protected readonly IProductRepository _repository;

        public ProductBehavior(IProductRepository repository)
        {
            _repository = repository;
        }


        public async Task CreateProductAsync(Product product)
        {
            if (product is null) throw new ArgumentNullException(nameof(product));

            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;

            await _repository.CreateProductAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (product is null) throw new ArgumentNullException(nameof(product));

            product.UpdatedAt = DateTime.Now;

            await _repository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(Product product)
        {
            if (product is null) throw new ArgumentNullException(nameof(product));

            await _repository.DeleteProductAsync(product);
        }
    }
}
