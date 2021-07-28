using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.RepositoryInterfaces;
using YuHan.CabsBooking.ApplicationCore.ServiceInterfaces;
using YuHan.CabsBooking.Infrastructure.Data;
using YuHan.CabsBooking.Infrastructure.Repositories;
using YuHan.CabsBooking.Infrastructure.Services;

namespace YuHan.CabsBooking.MVC
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
            services.AddControllersWithViews();

            services.AddScoped<ICabTypeRepository, CabTypeRepository>();
            services.AddScoped<ICabTypeService, CabTypeService>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IPlaceService, PlaceSerivce>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingHistoryService, BookingHistoryService>();
            services.AddScoped<IBookingHistoryRepository, BookingHistoryRepository>();

            services.AddDbContext<CabsBookingDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CabsBookingDbConnection"));
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
