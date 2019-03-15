using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace FitnessTracker.MongoDB.Exercise
{
    public class ExerciseClient : ClientBase<Models.Exercise>, IExerciseClient
    {
        public ExerciseClient(IMongoDatabase database)
            : base(database, "Exercise")
        {
        }

        public Task<IEnumerable<Models.Exercise>> GetExercisesInDateRange(DateTime from, DateTime to)
        {
            var builder = Builders<Models.Exercise>.Filter;
            var filter = builder.Gt(group => group.Recorded, from) & builder.Lt(group => group.Recorded, to);

            var exercises = _collection
                .Aggregate()
                .Sort(Builders<Models.Exercise>.Sort.Ascending(group => group.Recorded))
                .Match(filter)
                .ToEnumerable();

            return Task.FromResult(exercises);
        }
    }
}
