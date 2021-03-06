﻿using FitnessTracker.API.Configuration;
using FitnessTracker.API.Configuration.Options;
using FitnessTracker.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FitnessTracker.API
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
            services.AddOptions();

            services.AddCors(Configuration);
            services.AddMongo(Configuration);

            services.AddSingleton<IExerciseGroupResultAdapter, ExerciseGroupResultAdapter>();
            services.AddSingleton<IExerciseGroupSummaryAdapter, ExerciseGroupSummaryAdapter>();
            services.AddSingleton<IExerciseGroupSummaryPeriodAdapter, ExerciseGroupSummaryPeriodAdapter>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            IOptions<CorsOptions> corsOptions)
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

            app.UseCors(corsOptions);
            app.UseMvc();
        }
    }
}
