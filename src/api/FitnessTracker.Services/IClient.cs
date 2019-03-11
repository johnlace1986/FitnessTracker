using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.Services
{
    public interface IClient<TModel> where TModel : IModel
    {
        IEnumerable<TModel> Get();

        Task<TModel> GetById(Guid id, CancellationToken cancellationToken);

        Task<TModel> InsertAsync(IRequest<TModel> request, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    }
}
