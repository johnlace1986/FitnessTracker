using EnsureThat;
using FitnessTracker.API.Models.Results;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.API.Services
{
    public class ExerciseGroupResultAdapter : IExerciseGroupResultAdapter
    {
        private readonly IFitnessTrackerContext _context;

        public ExerciseGroupResultAdapter(IFitnessTrackerContext context)
        {
            Ensure.That(context).IsNotNull();

            _context = context;
        }

        public async Task<ExerciseGroupResult> AdaptAsync(ExerciseGroup group, ExerciseGroup first, CancellationToken cancellationToken)
        {
            var previous = await _context.ExerciseGroupClient.GetPreviousExerciseGroup(group.Recorded, cancellationToken).ConfigureAwait(false);

            var exercises = (await _context.ExerciseClient
                .GetExercisesInDateRange(previous?.Recorded ?? DateTime.MinValue, group.Recorded, cancellationToken)
                .ConfigureAwait(false)).ToArray();

            var result = new ExerciseGroupResult
            {
                Id = group.Id,
                Recorded = group.Recorded,
                Weight = group.Weight,
                CanDelete = previous != null,
                Exercises = exercises
            };


            return result;
        }
    }
}
