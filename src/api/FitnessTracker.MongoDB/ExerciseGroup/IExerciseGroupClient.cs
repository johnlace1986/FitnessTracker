using FitnessTracker.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.MongoDB.ExerciseGroup
{
    public interface IExerciseGroupClient : IClient<Models.ExerciseGroup>
    {
        Task<Models.ExerciseGroup> GetPreviousExerciseGroup(DateTime recorded, CancellationToken cancellationToken);

        Task<Models.ExerciseGroup> GetFirstExerciseGroup(CancellationToken cancellationToken);
    }
}
