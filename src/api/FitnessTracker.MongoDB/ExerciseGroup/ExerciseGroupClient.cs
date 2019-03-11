using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using FitnessTracker.Services;
using MongoDB.Driver;

namespace FitnessTracker.MongoDB.ExerciseGroup
{
    public class ExerciseGroupClient : ClientBase<Models.ExerciseGroup>, IClient<Models.ExerciseGroup>
    {
        public ExerciseGroupClient(IMongoDatabase database)
            : base(database, "ExerciseGroup")
        {
        }

        public async Task<Models.ExerciseGroup> InsertAsync(IRequest<Models.ExerciseGroup> request, CancellationToken cancellationToken)
        {
            var model = request.Map();

            await _collection.InsertOneAsync(model, new InsertOneOptions(), cancellationToken);

            return model;
        }
    }
}
