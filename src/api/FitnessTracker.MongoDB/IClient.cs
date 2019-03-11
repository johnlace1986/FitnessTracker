using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FitnessTracker.Services;

namespace FitnessTracker.MongoDB
{
    public interface IClient<TModel> where TModel : IModelBase
    {
        IEnumerable<TModel> Get();

        Task<TModel> GetById(Guid id, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    }
}
