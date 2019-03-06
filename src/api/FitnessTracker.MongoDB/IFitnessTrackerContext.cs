using System;
using System.Collections.Generic;
using System.Text;
using FitnessTracker.MongoDB.ExerciseGroup;

namespace FitnessTracker.MongoDB
{
    public interface IFitnessTrackerContext
    {
        IExerciseGroupClient ExerciseGroupClient { get; }
    }
}
