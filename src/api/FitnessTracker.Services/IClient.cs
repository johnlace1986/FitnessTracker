using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.Services
{
    public interface IClient<TModel> where TModel : IModel
    {
        Task<IEnumerable<TModel>> GetAsync(CancellationToken cancellationToken);

        Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<TModel> InsertAsync(IRequest<TModel> request, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    }
}
