using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using MongoDB.Driver;

namespace FitnessTracker.MongoDB.Exercise
{
    public class ExerciseClient : ClientBase<Models.Exercise>, IExerciseClient
    {
        public ExerciseClient(IMongoDatabase database)
            : base(database, "Exercise")
        {
        }

        public async Task<Models.Exercise> InsertAsync(DateTime recorded, TimeSpan timeTaken, double distance, int caloriesBurned, CancellationToken cancellationToken)
        {
            var exercise = new Models.Exercise
            {
                Id = Guid.NewGuid(),
                Recorded = recorded,
                TimeTaken = timeTaken,
                Distance = distance,
                CaloriesBurned = caloriesBurned
            };

            await _collection.InsertOneAsync(exercise, new InsertOneOptions(), cancellationToken);

            return exercise;
        }
    }
}
