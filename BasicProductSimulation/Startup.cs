using BasicProductSimulation.Repository;
using BasicProductSimulation.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace BasicProductSimulation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IContainer ApplicationContainer { get; private set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    corsBuilder => corsBuilder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddControllersAsServices();
            //services.AddTransient<IProductService, ProductService>();
            //services.AddTransient<IProductRepository, ProductRepository>();
            //services.AddTransient<Random, Random>();
            services.AddDbContext<ProductDB>(opt => opt.UseInMemoryDatabase("ProductList"));

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<Product>().As<IProduct>().InstancePerDependency();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerDependency();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerDependency();
            builder.RegisterType<Random>().InstancePerDependency();
            Console.WriteLine(builder);

            var ApplicationContainer = builder.Build();

            return ApplicationContainer.Resolve<IServiceProvider>();

            //return new AutofacServiceProvider(ApplicationContainer);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy"); 
            app.UseMvc();
        }
    }
}
