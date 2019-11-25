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
        protected readonly IMongoCollection<TModel> Collection;

        protected ClientBase(IMongoDatabase database, string collectionName)
        {
            Ensure.That(database).IsNotNull();

            Collection = database.GetCollection<TModel>(collectionName);
        }

        public async Task<IEnumerable<TModel>> GetAsync(int? limit, int? offset, CancellationToken cancellationToken)
        {
            var options = new FindOptions<TModel>
            {
                Sort = Builders<TModel>.Sort.Descending("Recorded"),
                Limit = limit,
                Skip = offset
            };

            var cursor = await Collection.FindAsync(FilterDefinition<TModel>.Empty, options, cancellationToken).ConfigureAwait(false);
            return await cursor.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return Collection.Find(GetByIdFilter(id)).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<TModel> InsertAsync(IRequest<TModel> request, CancellationToken cancellationToken)
        {
            var model = request.Map();

            await Collection.InsertOneAsync(model, new InsertOneOptions(), cancellationToken).ConfigureAwait(false);

            return model;
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Collection.DeleteOneAsync(GetByIdFilter(id), new DeleteOptions(), cancellationToken);
        }

        private static FilterDefinition<TModel> GetByIdFilter(Guid id)
        {
            return Builders<TModel>.Filter.Eq(model => model.Id, id);
        }
    }
}
