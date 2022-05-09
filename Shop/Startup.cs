using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Repository;
using Microsoft.AspNetCore.Http;
using Shop.Data.Models;

namespace Shop
{
    public class Startup
    {
        private IConfigurationRoot _configurationString;
        public Startup(IHostEnvironment hostEnvironment)
        {
            _configurationString = new ConfigurationBuilder().SetBasePath(hostEnvironment.ContentRootPath).AddJsonFile("dbSettings.json").Build();

        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_configurationString.GetConnectionString("DefaultConnection")));
            
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<IPhone, PhoneRepository> ();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
 
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
            
        }
    }
}
