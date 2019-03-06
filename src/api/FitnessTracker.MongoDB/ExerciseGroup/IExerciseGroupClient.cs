using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.MongoDB.ExerciseGroup
{
    public interface IExerciseGroupClient
    {
        IEnumerable<Models.ExerciseGroup> GetExerciseGroups();

        Task<Models.ExerciseGroup> InsertAsync(double weight, DateTime recorded, CancellationToken cancellationToken);
    }
}
