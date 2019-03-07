using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.MongoDB
{
    public interface IClient<out TModel> where TModel : Models.ModelBase
    {
        IEnumerable<TModel> Get();

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    }
}
