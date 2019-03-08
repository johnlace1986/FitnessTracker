using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.API.Configuration.Options
{
    public class CorsOptions
    {
        public IEnumerable<CorsPolicy> Policies { get; set; }
    }
}
