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

        public async Task<Models.ExerciseGroup> GetPreviousExerciseGroup(DateTime recorded, CancellationToken cancellationToken)
        {
            var pipline = new[]
            {
                new BsonDocument {{"$match", new BsonDocument {{"Recorded", new BsonDocument {{"$lt", recorded}}}}}},
                new BsonDocument {{"$sort", new BsonDocument {{"Recorded", -1}}}},
                new BsonDocument {{"$limit", 1}},
            };

            var cursor = await Collection.AggregateAsync<Models.ExerciseGroup>(pipline.ToList(), new AggregateOptions(), cancellationToken).ConfigureAwait(false);

            return await cursor.SingleOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Models.ExerciseGroup> GetFirstExerciseGroup(CancellationToken cancellationToken)
        {
            var options = new FindOptions<Models.ExerciseGroup>
            {
                BatchSize = 1,
                Sort = Builders<Models.ExerciseGroup>.Sort.Ascending(group => group.Recorded)
            };

            var cursor = await Collection.FindAsync(FilterDefinition<Models.ExerciseGroup>.Empty, options, cancellationToken);
            return await cursor.SingleOrDefaultAsync(cancellationToken);
        }
    }
}
