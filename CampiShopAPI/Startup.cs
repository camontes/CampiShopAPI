using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using CampiShopAPI.Domain.Behaviors;
using CampiShopAPI.Domain.Behaviors.Interfaces;
using CampiShopAPI.Domain.Repositories;
using CampiShopAPI.Infrastructure;
using CampiShopAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using CampiShopAPI.Queries.Interfaces;
using CampiShopAPI.Queries;

namespace CampiShopAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add SQL Server
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                serverOptions => serverOptions.MigrationsAssembly("CampiShopAPI"))
            );

            // Add Automapper
            services.AddAutoMapper(typeof(Startup));

            // User
            services.AddScoped<IUserBehavior, UserBehavior>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserQueries, UserQueries>();

            // Category
            services.AddScoped<ICategoryQueries, CategoryQueries>();
            services.AddScoped<ICategoryBehavior, CategoryBehavior>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Specification
            services.AddScoped<ISpecificationQueries, SpecificationQueries>();
            services.AddScoped<ISpecificationBehavior, SpecificationBehavior>();
            services.AddScoped<ISpecificationRepository, SpecificationRepository>();

            // DetailSpecification
            services.AddScoped<IDetailSpecificationQueries, DetailSpecificationQueries>();
            services.AddScoped<IDetailSpecificationBehavior, DetailSpecificationBehavior>();
            services.AddScoped<IDetailSpecificationRepository, DetailSpecificationRepository>();

            //Product
            services.AddScoped<IProductQueries, ProductQueries>();
            services.AddScoped<IProductBehavior, ProductBehavior>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // ProductDetail
            services.AddScoped<IProductSpecificationBehavior, ProductSpecificationBehavior>();
            services.AddScoped<IProductSpecificationRepository, ProductSpecificationRepository>();
            services.AddScoped<IProductSpecificationQueries, ProductSpecificationQueries>();

            // ShoppingCart
            services.AddScoped<IShoppingCartBehavior, ShoppingCartBehavior>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<IShoppingCartQueries, ShoppingCartQueries>();

            // Order
            services.AddScoped<IOrderQueries, OrderQueries>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderBehavior, OrderBehavior>();

            // DetailOrder
            services.AddScoped<IDetailOrderQueries, DetailOrderQueries>();
            services.AddScoped<IDetailOrderRepository, DetailOrderRepository>();
            services.AddScoped<IDetailOrderBehavior, DetailOrderBehavior>();

            // StateOrder
            services.AddScoped<IStateOrderQueries, StateOrderQueries>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
