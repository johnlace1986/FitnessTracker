using EnsureThat;
using FitnessTracker.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.MongoDB
{
    public abstract class ClientBase<TModel> : IClient<TModel>
        where TModel: IModel
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

        public Task<TModel> GetById(Guid id, CancellationToken cancellationToken)
        {
            return _collection.Find(GetByIdFilter(id)).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<TModel> InsertAsync(IRequest<TModel> request, CancellationToken cancellationToken)
        {
            var model = request.Map();

            await _collection.InsertOneAsync(model, new InsertOneOptions(), cancellationToken);

            return model;
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return _collection.DeleteOneAsync(GetByIdFilter(id), new DeleteOptions(), cancellationToken);
        }

        private FilterDefinition<TModel> GetByIdFilter(Guid id)
        {
            return Builders<TModel>.Filter.Eq(model => model.Id, id);
        }
    }
}
