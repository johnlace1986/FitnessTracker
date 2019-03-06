using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.API.Models
{
    public class ExerciseGroupDto
    {
        public double Weight { get; set; }

        public DateTime Recorded { get; set; }
    }
}
