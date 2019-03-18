using FitnessTracker.Models;
using System;
using System.Collections.Generic;

namespace FitnessTracker.API.Models.Results
{
    public class ExerciseGroupResult : ExerciseGroup
    {
        public bool CanDelete { get; set; }

        public TimeSpan TotalTimeDieting { get; set; }

        public double WeightLostThisWeek { get; set; }

        public double WeightLostInTotal { get; set; }

        public double WeightLosingPerWeek { get; set; }

        public double TotalExerciseDistance { get; set; }

        public TimeSpan TotalTimeSpentExercising { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }
    }
}
