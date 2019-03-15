using FitnessTracker.MongoDB.Exercise;
using FitnessTracker.MongoDB.ExerciseGroup;

namespace FitnessTracker.MongoDB
{
    public interface IFitnessTrackerContext
    {
        IExerciseGroupClient ExerciseGroupClient { get; }

        IExerciseClient ExerciseClient { get; }
    }
}
