using MongoDB.Bson;
using System;

namespace FitnessTracker.MongoDB
{
    public static class BsonDocumentHelper
    {
        public static BsonDocument Map(string name, BsonDocument value)
        {
            return new BsonDocument { { name, value } };
        }

        public static BsonDocument Map(string name, BsonArray values)
        {
            return new BsonDocument { { name, values } };
        }

        public static BsonDocument Map(string name, int value)
        {
            return new BsonDocument { { name, value } };
        }

        public static BsonDocument Map(string name, DateTime value)
        {
            return new BsonDocument { { name, value } };
        }
    }
}
