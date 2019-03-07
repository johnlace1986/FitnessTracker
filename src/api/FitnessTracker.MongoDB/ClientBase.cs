using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using MongoDB.Driver;

namespace FitnessTracker.MongoDB
{
    public abstract class ClientBase<TModel> where TModel: Models.ModelBase
    {
        protected readonly IMongoCollection<TModel> _collection;

        protected ClientBase(IMongoDatabase database, string collectionName)
        {
            Ensure.That(database).IsNotNull();

            _collection = database.GetCollection<TModel>(collectionName);
        }

        public IEnumerable<TModel> Get()
        {
            return _collection.Find(FilterDefinition<TModel>.Empty)
                .Sort(Builders<TModel>.Sort.Ascending("Recorded"))
                .ToEnumerable();
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<TModel>.Filter.Eq(model => model.Id, id);
            return _collection.DeleteOneAsync(filter, new DeleteOptions(), cancellationToken);
        }
    }
}
