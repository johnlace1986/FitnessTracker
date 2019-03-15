using FitnessTracker.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.MongoDB.ExerciseGroup
{
    public interface IExerciseGroupClient : IClient<Models.ExerciseGroup>
    {
        Task<Models.ExerciseGroup> GetPreviousExerciseGroupById(DateTime recorded, CancellationToken cancellationToken);
    }
}
