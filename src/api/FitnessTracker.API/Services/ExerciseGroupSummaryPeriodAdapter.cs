using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitnessTracker.API.Models.Results;

namespace FitnessTracker.API.Services
{
    public class ExerciseGroupSummaryPeriodAdapter : IExerciseGroupSummaryPeriodAdapter
    {
        public IEnumerable<ExerciseGroupSummaryPeriod> Adapt(IEnumerable<ExerciseGroupSummary> summaries) =>
            summaries.GroupBy(summary => new {Title = $"{summary.Recorded:MMMM} {summary.Recorded.Year}"})
                .Select(summaryGroup =>
                    new ExerciseGroupSummaryPeriod
                    {
                        Title = summaryGroup.Key.Title, Summaries = summaryGroup.AsEnumerable()
                    });
    }
}
