﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.MongoDB.Exercise
{
    public class ExerciseClient : ClientBase<Models.Exercise>, IExerciseClient
    {
        public ExerciseClient(IMongoDatabase database)
            : base(database, "Exercise")
        {
        }

        public async Task<IEnumerable<Models.Exercise>> GetExercisesInDateRange(DateTime from, DateTime to, CancellationToken cancellationToken)
        {
            var pipeline = new[]
            {
                new BsonDocument {{"$sort", new BsonDocument {{"Recorded", 1}}}},
                new BsonDocument {{"$match", new BsonDocument{{"$and", new BsonArray
                {
                    new BsonDocument{{"Recorded", new BsonDocument{{"$gt", from}}}},
                    new BsonDocument{{"Recorded", new BsonDocument{{"$lt", to}}}}
                }}}}}
            };

            var cursor = await Collection.AggregateAsync<Models.Exercise>(pipeline.ToList(), new AggregateOptions(), cancellationToken).ConfigureAwait(false);
            var result = await cursor.ToListAsync(cancellationToken).ConfigureAwait(false);

            return result;
        }
    }
}
