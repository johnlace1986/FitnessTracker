using FitnessTracker.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.MongoDB.Exercise
{
    public interface IExerciseClient : IClient<Models.Exercise>
    {
        Task<IEnumerable<Models.Exercise>> GetExercisesInDateRange(DateTime from, DateTime to, CancellationToken cancellationToken);
    }
}
