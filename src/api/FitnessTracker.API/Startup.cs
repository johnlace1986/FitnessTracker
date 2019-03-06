using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.MongoDB;
using FitnessTracker.MongoDB.ExerciseGroup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FitnessTracker.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string _corsPolicyName = "FitnessTracker.Web";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                var origins = Configuration.GetSection("CorsOrigins")
                    .AsEnumerable()
                    .Where(origin => !string.IsNullOrWhiteSpace(origin.Value))
                    .Select(origin => origin.Value);

                options.AddPolicy(_corsPolicyName,
                    builder =>
                    {
                        builder.WithOrigins(origins.ToArray())
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IFitnessTrackerContext>(provider =>
            {
                var connectionString = Configuration.GetConnectionString("mongoDB");
                var databaseName = Configuration["MongoDB:DatabaseName"];

                return new FitnessTrackerContext(connectionString, databaseName);
            });
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

            app.UseCors(_corsPolicyName);

            app.UseMvc();
        }
    }
}
