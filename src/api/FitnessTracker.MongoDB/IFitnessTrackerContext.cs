using FitnessTracker.Services;

namespace FitnessTracker.MongoDB
{
    public interface IFitnessTrackerContext
    {
        IClient<Models.ExerciseGroup> ExerciseGroupClient { get; }

        IClient<Models.Exercise> ExerciseClient { get; }
    }
}
