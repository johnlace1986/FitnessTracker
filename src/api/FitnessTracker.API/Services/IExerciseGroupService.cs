using FitnessTracker.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.API.Services
{
    public interface IExerciseGroupService
    {
        Task<IEnumerable<Exercise>> GetExercisesAsync(ExerciseGroup group, CancellationToken cancellationToken);
    }
}
