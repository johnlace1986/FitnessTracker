using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using MongoDB.Driver;

namespace FitnessTracker.MongoDB.ExerciseGroup
{
    public class ExerciseGroupClient : ClientBase<Models.ExerciseGroup>, IExerciseGroupClient
    {
        public ExerciseGroupClient(IMongoDatabase database)
            : base(database, "ExerciseGroup")
        {
        }

        public async Task<Models.ExerciseGroup> InsertAsync(DateTime recorded, double weight, CancellationToken cancellationToken)
        {
            var exerciseGroup = new Models.ExerciseGroup
            {
                Id = Guid.NewGuid(),
                Weight = weight,
                Recorded = recorded
            };

            await _collection.InsertOneAsync(exerciseGroup, new InsertOneOptions(), cancellationToken);

            return exerciseGroup;
        }
    }
}
