using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.MongoDB
{
    public interface IClient<TModel> where TModel : Models.ModelBase
    {
        IEnumerable<TModel> Get();

        Task<TModel> GetById(Guid id, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    }
}
