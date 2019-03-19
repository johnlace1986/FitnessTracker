using System.Collections.Generic;

namespace FitnessTracker.API.Models.Results
{
    public class ExerciseGroupSummaryPeriod
    {
        public string Title { get; set; }

        public IEnumerable<ExerciseGroupSummary> Summaries { get; set; }
    }
}
