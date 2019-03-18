using FitnessTracker.API.Models.Results;
using FitnessTracker.Models;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.API.Services
{
    public interface IExerciseGroupService
    {
        Task<ExerciseGroupResult> GetExercisesAsync(ExerciseGroup group, CancellationToken cancellationToken);
    }
}
