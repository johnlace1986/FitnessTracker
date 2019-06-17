using FitnessTracker.Models;
using System;

namespace FitnessTracker.API.Models.Results
{
    public abstract class ExerciseGroupResultBase : ExerciseGroup
    {
        public bool CanDelete { get; set; }
    }
}
