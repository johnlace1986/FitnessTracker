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
        public IEnumerable<ExerciseGroupSummaryPeriod> Adapt(IEnumerable<ExerciseGroupSummary> summaries)
        {
            return
                from summary in summaries
                group summary by new {Title = $"{summary.Recorded:MMMM} {summary.Recorded.Year}"}
                into summaryGroup
                select new ExerciseGroupSummaryPeriod
                {
                    Title = summaryGroup.Key.Title,
                    Summaries = summaryGroup.AsEnumerable()
                };

        }
    }
}
