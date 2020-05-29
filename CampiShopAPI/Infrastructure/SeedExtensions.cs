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

		public static readonly StateOrder[] StateOrdersSeed = new StateOrder[] {
			new StateOrder
			{
				Id = 1,
				Name = "En proceso"
			},
			new StateOrder
			{
				Id = 2,
				Name = "Pendiente"
			},
			new StateOrder
			{
				Id = 3,
				Name = "Recibido"
			},
			new StateOrder
			{
				Id = 4,
				Name = "Despachado"
			},
			new StateOrder
			{
				Id = 5,
				Name = "Entregado"
			}
		};
		public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               UsersSeed
            );
			modelBuilder.Entity<StateOrder>().HasData(
			   StateOrdersSeed
			);
		}
    }
}
