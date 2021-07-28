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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.RepositoryInterfaces;
using YuHan.CabsBooking.ApplicationCore.ServiceInterfaces;
using YuHan.CabsBooking.Infrastructure.Data;
using YuHan.CabsBooking.Infrastructure.Repositories;
using YuHan.CabsBooking.Infrastructure.Services;

namespace YuHan.CabsBooking
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

            services.AddControllers();
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "YuHan.CabsBooking", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "YuHan.CabsBooking v1"));
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
