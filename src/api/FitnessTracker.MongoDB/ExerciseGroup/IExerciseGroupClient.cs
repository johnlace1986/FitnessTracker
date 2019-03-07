using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.MongoDB.ExerciseGroup
{
    public interface IExerciseGroupClient : IClient<Models.ExerciseGroup>
    {
        Task<Models.ExerciseGroup> InsertAsync(DateTime recorded, double weight, CancellationToken cancellationToken);
    }
}
