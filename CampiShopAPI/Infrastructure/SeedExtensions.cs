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

		public static readonly Category[] CategoriesSeed = new Category[] {
			new Category
			{
				Id = 1,
				Name="Computers",
				Description="Here you can find all about computers",
				CreatedAt=DateTime.Now,
				UpdatedAt=DateTime.Now				
			},
			new Category
			{
				Id = 2,
				Name="TV's",
				Description="Here you can find all about TV's",
				CreatedAt=DateTime.Now,
				UpdatedAt=DateTime.Now
			},
			new Category
			{
				Id = 3,
				Name="Videogames",
				Description="Here you can find all about videogames",
				CreatedAt=DateTime.Now,
				UpdatedAt=DateTime.Now
			},
			new Category
			{
				Id = 4,
				Name="Cellphones",
				Description="Here you can find all about cell phones",
				CreatedAt=DateTime.Now,
				UpdatedAt=DateTime.Now
			}
		};

		public static readonly StateOrder[] StateOrdersSeed = new StateOrder[] {
			new StateOrder
			{
				Id = 1,
				Name = "Pendiente"
			},
			new StateOrder
			{
				Id = 2,
				Name = "Recibido"
			},
			new StateOrder
			{
				Id = 3,
				Name = "Despachado"
			},
			new StateOrder
			{
				Id = 4,
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
			modelBuilder.Entity<Category>().HasData(
			   CategoriesSeed
			);
		}
    }
}
