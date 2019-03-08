using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.API.Configuration.Options
{
    public class CorsPolicy
    {
        public string PolicyName { get; set; }

        public IEnumerable<string> AllowedOrigins { get; set; }
    }
}
