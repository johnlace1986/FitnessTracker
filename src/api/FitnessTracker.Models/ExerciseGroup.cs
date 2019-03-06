using System;

namespace FitnessTracker.Models
{
    public class ExerciseGroup
    {
        public Guid Id { get; set; }

        public double Weight { get; set; }

        public DateTime Recorded { get; set; }
    }
}
