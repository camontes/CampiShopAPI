using CampiShopAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Infrastructure
{
    public static class SeedExtensions
    {
        public static readonly User[] UsersSeed = new User[] {
            new User
            {
                Username = "sample",
                Name="Mr. Sample",
                Photo="photo.png",
            }
        };

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               UsersSeed
            );
        }
    }
}
