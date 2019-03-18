using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace FitnessTracker.MongoDB.ExerciseGroup
{
    public class ExerciseGroupClient : ClientBase<Models.ExerciseGroup>, IExerciseGroupClient
    {
        public ExerciseGroupClient(IMongoDatabase database)
            : base(database, "ExerciseGroup")
        {
        }

        public async Task<Models.ExerciseGroup> GetPreviousExerciseGroupById(DateTime recorded, CancellationToken cancellationToken)
        {
            var pipline = new[]
            {
                new BsonDocument {{"$match", new BsonDocument {{"Recorded", new BsonDocument {{"$lt", recorded}}}}}},
                new BsonDocument {{"$sort", new BsonDocument {{"Recorded", -1}}}},
                new BsonDocument {{"$limit", 1}},
            };

            var cursor = await _collection.AggregateAsync<Models.ExerciseGroup>(pipline.ToList(), new AggregateOptions(), cancellationToken);

            return await cursor.SingleOrDefaultAsync(cancellationToken);
        }
    }
}
