using CampiShopAPI.Domain.Behaviors.Interfaces;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampiShopAPI.Domain.Behaviors
{
    public class UserBehavior : IUserBehavior
    {
        protected readonly IUserRepository _repository;

        public UserBehavior(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateUserAsync(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));
            await _repository.CreateUserAsync(user);
        }
    }
}