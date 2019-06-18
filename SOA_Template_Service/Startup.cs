using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CarPartsService.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CarPartsService
{
    using Services;
    using BusinessLogic;
    using CarPartsService.DAL.Repositories.Interfaces;
    using CarPartsService.DAL.Repositories;
    // using ProviderService.BusinessLogic.Interfaces;

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
            services.AddDbContext<CarPartContext>(opt =>
                //String goes in config, or pulled from a DB
                opt.UseSqlite("Data Source=carParts.db")
                );

            services.AddScoped<CarPartsService>();
            // services.AddTransient<IPhysicianProvider, PhysicianProvider>();
            services.AddScoped<ICarPartsRepository, CarPartsRepository>();
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMvc();
        }
    }
}
