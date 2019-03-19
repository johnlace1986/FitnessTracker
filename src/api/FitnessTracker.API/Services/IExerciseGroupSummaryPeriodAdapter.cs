using FitnessTracker.API.Models.Results;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.API.Services
{
    public interface IExerciseGroupSummaryPeriodAdapter
    {
        IEnumerable<ExerciseGroupSummaryPeriod> Adapt(IEnumerable<ExerciseGroupSummary> summaries);
    }
}
