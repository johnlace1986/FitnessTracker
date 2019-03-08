using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.API.Configuration.Options;
using FitnessTracker.MongoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessTracker.API.Configuration
{
    public static class MongoConfiguration
    {
        public static void AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoOptions>(configuration.GetSection("MongoDB"));

            services.AddSingleton<IFitnessTrackerContext>(provider =>
            {
                var options = configuration.GetSection("MongoDB").Get<MongoOptions>();

                return new FitnessTrackerContext(options.ConnectionString, options.DatabaseName);
            });

        }
    }
}
