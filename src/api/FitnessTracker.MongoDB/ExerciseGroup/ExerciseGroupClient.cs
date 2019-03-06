using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using MongoDB.Driver;

namespace FitnessTracker.MongoDB.ExerciseGroup
{
    public class ExerciseGroupClient : IExerciseGroupClient
    {
        private readonly IMongoCollection<Models.ExerciseGroup> _collection;

        public ExerciseGroupClient(IMongoDatabase database)
        {
            Ensure.That(database).IsNotNull();

            _collection = database.GetCollection<Models.ExerciseGroup>("ExerciseGroup");
        }

        public IEnumerable<Models.ExerciseGroup> GetExerciseGroups()
        {
            return _collection.Find(FilterDefinition<Models.ExerciseGroup>.Empty)
                .Sort(Builders<Models.ExerciseGroup>.Sort.Ascending("Recorded"))
                .ToEnumerable();
        }

        public async Task<Models.ExerciseGroup> InsertAsync(double weight, DateTime recorded, CancellationToken cancellationToken)
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

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Models.ExerciseGroup>.Filter.Eq(exerciseGroup => exerciseGroup.Id, id);
            return _collection.DeleteOneAsync(filter, new DeleteOptions(), cancellationToken);
        }
    }
}
