using System;
using System.Collections.Generic;
using System.Text;
using FitnessTracker.Services;

namespace FitnessTracker.Models
{
    public class Exercise : IModel
    {
        public Guid Id { get; set; }

        public DateTime Recorded { get; set; }

        public TimeSpan TimeTaken { get; set; }

        public double Distance { get; set; }

        public int CaloriesBurned { get; set; }
    }
}
