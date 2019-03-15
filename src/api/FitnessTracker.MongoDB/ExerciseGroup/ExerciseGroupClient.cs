using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.MongoDB.ExerciseGroup
{
    public class ExerciseGroupClient : ClientBase<Models.ExerciseGroup>, IExerciseGroupClient
    {
        public ExerciseGroupClient(IMongoDatabase database)
            : base(database, "ExerciseGroup")
        {
        }

        public Task<Models.ExerciseGroup> GetPreviousExerciseGroupById(DateTime recorded, CancellationToken cancellationToken)
        {
            var previous = _collection
                .Aggregate()
                .Match(Builders<Models.ExerciseGroup>.Filter.Lt(group => group.Recorded, recorded))
                .Sort(Builders<Models.ExerciseGroup>.Sort.Descending(group => group.Recorded))
                .Limit(1)
                .SingleOrDefault();

            return Task.FromResult(previous);
        }
    }
}
