using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Commands
{
    public  class CreateUserCommand
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        public string Photo { get; set; }
    }
}
