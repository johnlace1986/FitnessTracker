using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.API.Models
{
    public class ExerciseDto
    {
        public DateTime Recorded { get; set; }

        public TimeSpan TimeTaken { get; set; }

        public double Distance { get; set; }

        public int CaloriesBurned { get; set; }
    }
}
