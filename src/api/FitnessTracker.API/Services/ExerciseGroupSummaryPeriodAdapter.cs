using System;
using FitnessTracker.API.Models.Results;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.API.Services
{
    public class ExerciseGroupSummaryPeriodAdapter : IExerciseGroupSummaryPeriodAdapter
    {
        public IEnumerable<ExerciseGroupSummaryPeriod> Adapt(IEnumerable<ExerciseGroupSummary> summaries) =>
            summaries.GroupBy(summary => new {summary.Recorded.Year, summary.Recorded.Month})
                .Select(summaryGroup =>
                {
                    var firstDayOfPeriod = new DateTime(summaryGroup.Key.Year, summaryGroup.Key.Month, 1);

                    return new ExerciseGroupSummaryPeriod
                    {
                        Title = $"{firstDayOfPeriod:MMMM} {firstDayOfPeriod.Year}",
                        Year = summaryGroup.Key.Year,
                        Month = summaryGroup.Key.Month,
                        Summaries = summaryGroup.AsEnumerable()
                    };
                });
    }
}
