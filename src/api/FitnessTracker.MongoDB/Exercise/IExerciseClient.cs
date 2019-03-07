using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.MongoDB.Exercise
{
    public interface IExerciseClient : IClient<Models.Exercise>
    {
        Task<Models.Exercise> InsertAsync(DateTime recorded, TimeSpan timeTaken, double distance, int caloriesBurned, CancellationToken cancellationToken);
    }
}
