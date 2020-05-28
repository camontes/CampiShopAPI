using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampiShopAPI.Commands;
using CampiShopAPI.Domain.Behaviors.Interfaces;
using CampiShopAPI.Domain.Models;
using CampiShopAPI.Queries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampiShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBehavior _behavior;

        private readonly IUserQueries _queries;

        private readonly IMapper _mapper;

        public UsersController
            (
                IUserBehavior behavior, 
                IUserQueries queries, 
                IMapper mapper
            )
        {
            _behavior = behavior;
            _queries = queries;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<User>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<User>> CreateUserAsync(CreateUserCommand createUserCommand)
        {
            var existingUser = await _queries.FindByUsernameAsync(createUserCommand.Username);
            if (existingUser != null)
            {
                return Conflict();
            }

            var user = _mapper.Map<User>(createUserCommand);
            await _behavior.CreateUserAsync(user);
            return user;
        }
    }
}
