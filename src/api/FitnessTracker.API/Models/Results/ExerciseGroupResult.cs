using FitnessTracker.Models;
using System.Collections.Generic;

namespace FitnessTracker.API.Models.Results
{
    public class ExerciseGroupResult : ExerciseGroupResultBase
    {
        public IEnumerable<Exercise> Exercises { get; set; }
    }
}
