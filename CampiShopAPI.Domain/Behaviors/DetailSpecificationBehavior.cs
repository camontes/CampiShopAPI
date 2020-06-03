using CampiShopAPI.Domain.Models;
using CampiShopAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors.Interfaces
{
   public class DetailSpecificationBehavior : IDetailSpecificationBehavior
    {
        protected readonly IDetailSpecificationRepository _repository;

        public DetailSpecificationBehavior(IDetailSpecificationRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateDetailSpecificationAsync(DetailSpecification detailSpecification)
        {
            if (detailSpecification is null) throw new ArgumentNullException(nameof(detailSpecification));

            await _repository.CreateDetailSpecificationAsync(detailSpecification);
        }

        public async Task UpdateDetailSpecificationAsync(DetailSpecification detailSpecification)
        {
            if (detailSpecification is null) throw new ArgumentNullException(nameof(detailSpecification));

            await _repository.UpdateDetailSpecificationAsync(detailSpecification);
        }

        public async Task DeleteDetailSpecificationAsync(DetailSpecification detailSpecification)
        {
            if (detailSpecification is null) throw new ArgumentNullException(nameof(detailSpecification));

            await _repository.DeleteDetailSpecificationAsync(detailSpecification);
        }
    }
}
