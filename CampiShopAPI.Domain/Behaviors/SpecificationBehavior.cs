using CampiShopAPI.Domain.Behaviors.Interfaces;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors
{
    public class SpecificationBehavior : ISpecificationBehavior
    {
        protected readonly ISpecificationRepository _repository;

        public SpecificationBehavior(ISpecificationRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateSpecificationAsync(Specification specification)
        {
            if (specification is null) throw new ArgumentNullException(nameof(specification));

            await _repository.CreateSpecificationAsync(specification);
        }

        public async Task UpdateSpecificationAsync(Specification specification)
        {
            if (specification is null) throw new ArgumentNullException(nameof(specification));

            await _repository.UpdateSpecificationAsync(specification);
        }

        public async Task DeleteSpecificationAsync(Specification specification)
        {
            if (specification is null) throw new ArgumentNullException(nameof(specification));

            await _repository.DeleteSpecificationAsync(specification);
        }
    }
}
