using EnsureThat;
using FitnessTracker.API.Models.Results;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.API.Services
{
    public class ExerciseGroupService : IExerciseGroupService
    {
        private readonly IFitnessTrackerContext _context;

        public ExerciseGroupService(IFitnessTrackerContext context)
        {
            Ensure.That(context).IsNotNull();

            _context = context;
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync(ExerciseGroup group, CancellationToken cancellationToken)
        {
            var previous = await _context.ExerciseGroupClient.GetPreviousExerciseGroupById(group.Recorded, cancellationToken).ConfigureAwait(false);

            return await _context.ExerciseClient.GetExercisesInDateRange(previous?.Recorded ?? DateTime.MinValue, group.Recorded, cancellationToken).ConfigureAwait(false);
        }
    }
}
