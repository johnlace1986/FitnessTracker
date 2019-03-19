using FitnessTracker.API.Models.Results;
using FitnessTracker.Models;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.API.Services
{
    public interface IExerciseGroupResultAdapter
    {
        Task<ExerciseGroupResult> AdaptAsync(ExerciseGroup group, ExerciseGroup first, CancellationToken cancellationToken);
    }
}
