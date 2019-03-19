using FitnessTracker.API.Models.Results;
using FitnessTracker.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.API.Services
{
    public interface IExerciseGroupSummaryAdapter
    {
        Task<IEnumerable<ExerciseGroupSummary>> AdaptAsync(IEnumerable<ExerciseGroup> groups, ExerciseGroup first, CancellationToken cancellationToken);
    }
}
