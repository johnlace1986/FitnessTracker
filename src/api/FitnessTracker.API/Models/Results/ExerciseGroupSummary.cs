using System;

namespace FitnessTracker.API.Models.Results
{
    public class ExerciseGroupSummary : ExerciseGroupResultBase
    {
        public DateTime StartDate { get; set; }

        public int ExerciseCount { get; set; }
    }
}
