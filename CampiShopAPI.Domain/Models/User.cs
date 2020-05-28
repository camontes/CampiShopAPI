using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CampiShopAPI.Domain.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }
    }
}
