using BookStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BS_DBContext>(opt =>
                {
                    opt.UseSqlServer(Configuration["Connectionstrings:BSConn"]);
                }
            );
            services.AddScoped<IBookStoreRespository, BSRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache(); // setup in Memmory data storage
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDeveloperExceptionPage();
            app.UseSession();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("categoryPage", "{category}/Page{book_p:int}",
                                            new { Controller = "Home", action = "Index" });//electronics/Page1
                endpoints.MapControllerRoute("page", "Page{book_p:int}",
                                            new { Controller = "Home", action = "Index", book_p = 1 });//Page1
                endpoints.MapControllerRoute("category", "{category}",
                                            new { Controller = "Home", action = "Index", book_p = 1 });// /electronics

                endpoints.MapControllerRoute("pageroute","Books/Page{book_p:int}", 
                                                new {Controller = "Home", action = "Index" });
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
            LoadDataFile.LoadData(app);
        }
    }
}
