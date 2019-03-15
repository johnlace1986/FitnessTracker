using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Models;
using FitnessTracker.Services;

namespace FitnessTracker.API.Models.Results
{
    public class ExerciseGroupResult : ExerciseGroup, IResult
    {
        public IEnumerable<Exercise> Exercises { get; set; }
    }
}
