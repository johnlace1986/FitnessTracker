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
    public class ExerciseGroupService : IExerciseGroupService
    {
        private readonly IFitnessTrackerContext _context;

        public ExerciseGroupService(IFitnessTrackerContext context)
        {
            Ensure.That(context).IsNotNull();

            _context = context;
        }

        public async Task<ExerciseGroupResult> GetExercisesAsync(ExerciseGroup group, CancellationToken cancellationToken)
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
                Exercises = exercises
            };

            if (previous == null)
            {
                result.CanDelete = false;
            }
            else
            {
                var first = await _context.ExerciseGroupClient.GetFirstExerciseGroup(cancellationToken).ConfigureAwait(false);

                result.CanDelete = true;
                result.TotalTimeDieting = group.Recorded - first.Recorded;
                result.WeightLostThisWeek = group.Weight - previous.Weight;
                result.WeightLostInTotal = group.Weight - first.Weight;
                ///TODO: result.WeightLosingPerWeek
                result.TotalExerciseDistance = exercises.Sum(exercise => exercise.Distance);
                result.TotalTimeSpentExercising = TimeSpan.FromMilliseconds(exercises.Sum(exercise => exercise.TimeTaken.TotalMilliseconds));
            }

            return result;
        }
    }
}
