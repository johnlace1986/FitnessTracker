using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Models;

namespace FitnessTracker.API.Models.Results
{
    public class ExerciseGroupSummary : ExerciseGroup
    {
        public int ExerciseCount { get; set; }
    }
}
