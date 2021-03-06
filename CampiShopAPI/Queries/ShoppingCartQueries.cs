﻿using CampiShopAPI.Infrastructure;
using CampiShopAPI.Queries.Interfaces;
using CampiShopAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Queries
{
    public class ShoppingCartQueries : IShoppingCartQueries
    {
        protected readonly ApplicationDbContext _context;

        public ShoppingCartQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShoppingCartViewModel>> FindAllAsync()
        {
            return await _context.ShoppingCarts.AsNoTracking()
                .Include(p => p.Product)
                .Select(sc => new ShoppingCartViewModel
                 {
                     Id = sc.Id,
                     Amount = sc.Amount,
                     Total = sc.Total,
                     PriceProduct = sc.Product.Price,
                     ProductId = sc.ProductId,
                     ProductName = sc.Product.Name,
                     Username = sc.Username
                 })
                .ToListAsync();
        }

        public async Task<ShoppingCartViewModel> FindByIdAsync(int id)
        {
            return await _context.ShoppingCarts.AsNoTracking()
                .Include(p => p.Product)
                .Select(sc => new ShoppingCartViewModel
                {
                    Id = sc.Id,
                    Amount = sc.Amount,
                    Total = sc.Total,
                    PriceProduct = sc.Product.Price,
                    ProductId = sc.ProductId,
                    ProductName = sc.Product.Name,
                    Username = sc.Username
                })
                .FirstOrDefaultAsync(shoppingCart => shoppingCart.Id == id);
        }

        public async Task<ShoppingCartViewModel> FindByIdUsernameAsync(int productId, string username)
        {
            return await _context.ShoppingCarts.AsNoTracking()
                .Include(p => p.Product)
                .Select(sc => new ShoppingCartViewModel
                {
                    Id = sc.Id,
                    Amount = sc.Amount,
                    Total = sc.Total,
                    PriceProduct = sc.Product.Price,
                    ProductId = sc.ProductId,
                    ProductName = sc.Product.Name,
                    Username = sc.Username
                })
                .FirstOrDefaultAsync(shoppingCart => shoppingCart.ProductId == productId && shoppingCart.Username == username);
        }

        public async Task<List<ShoppingCartViewModel>> FindAllByUsernameAsync(string username)
        {
            return await _context.ShoppingCarts.AsNoTracking()
                .Include(p => p.Product)
                .Select(sc => new ShoppingCartViewModel
                {
                    Id = sc.Id,
                    Amount = sc.Amount,
                    Total = sc.Total,
                    ProductId = sc.ProductId,
                    PriceProduct = sc.Product.Price,
                    ProductName = sc.Product.Name,
                    Username = sc.Username
                })
                .Where(shoppingCart => shoppingCart.Username ==username)
                .ToListAsync();
        }
    }
}
