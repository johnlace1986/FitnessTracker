using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.API.Models
{
    public abstract class DtoBase
    {
        public DateTime Recorded { get; set; }
    }
}
