using EnsureThat;
using FitnessTracker.API.Models.Results;
using FitnessTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.API.Services
{
    public class ExerciseGroupSummaryAdapter : IExerciseGroupSummaryAdapter
    {
        private readonly IExerciseGroupResultAdapter _resultAdapter;

        public ExerciseGroupSummaryAdapter(IExerciseGroupResultAdapter resultAdapter)
        {
            Ensure.That(resultAdapter);

            _resultAdapter = resultAdapter;
        }
        public async Task<IEnumerable<ExerciseGroupSummary>> AdaptAsync(IEnumerable<ExerciseGroup> groups, ExerciseGroup first, CancellationToken cancellationToken)
        {
            var results = await Task.WhenAll(groups.Select(async (group) =>
            {
                var result = await _resultAdapter.AdaptAsync(group, first, cancellationToken).ConfigureAwait(false);

                return new ExerciseGroupSummary
                {
                    Id = result.Id,
                    Recorded = result.Recorded,
                    Weight = result.Weight,
                    CanDelete = result.CanDelete,
                    StartDate = first.Recorded,
                    ExerciseCount = result.Exercises.Count()
                };
            })).ConfigureAwait(false);

            return results;
        }
    }
}
