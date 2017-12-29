using CoreApp.DbAccess.Context;
using CoreApp.DbAccess.Interfaces;
using CoreApp.DbAccess.Models;
using CoreApp.DbAccess.Repositories;
using CoreApp.DbAccess.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CoreApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = this.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ProdDbContext>(op=>op.UseSqlServer(connection));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<CategoryUOW>();
            services.AddScoped<ProductTypeUOW>();
            services.AddScoped<ProductUOW>();
            services.AddScoped<UnitUOW>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "REST API"
                });
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API v1");
            });

            app.UseMvc();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "api/{controller=Product}/{action=Get}/{id?}");
            //});
        }
    }
}