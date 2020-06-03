using CampiShopAPI.Domain.Behaviors.Interfaces;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors
{
    public class ProductSpecificationBehavior : IProductSpecificationBehavior
    {
        protected readonly IProductSpecificationRepository _repository;

        public ProductSpecificationBehavior(IProductSpecificationRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateProductSpecificationAsync(int productId, int detailSpecificationId)
        {
            ProductSpecification productSpecification = new ProductSpecification
            {
                ProductId = productId,
                DetailSpecificationId = detailSpecificationId
            };

            await _repository.CreateProductSpecificationAsync(productSpecification);
        }
    }
}
