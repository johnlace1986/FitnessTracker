using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Models
{
    public class Exercise : ModelBase
    {
        public TimeSpan TimeTaken { get; set; }

        public double Distance { get; set; }

        public int CaloriesBurned { get; set; }
    }
}
