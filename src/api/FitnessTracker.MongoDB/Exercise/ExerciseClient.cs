using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using FitnessTracker.Services;
using MongoDB.Driver;

namespace FitnessTracker.MongoDB.Exercise
{
    public class ExerciseClient : ClientBase<Models.Exercise>
    {
        public ExerciseClient(IMongoDatabase database)
            : base(database, "Exercise")
        {
        }

        public async Task<Models.Exercise> InsertAsync(IRequest<Models.Exercise> request, CancellationToken cancellationToken)
        {
            var model = request.Map();

            await _collection.InsertOneAsync(model, new InsertOneOptions(), cancellationToken);

            return model;
        }
    }
}
