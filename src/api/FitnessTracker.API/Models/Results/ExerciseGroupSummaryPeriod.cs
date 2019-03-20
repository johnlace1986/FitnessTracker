using System.Collections.Generic;

namespace FitnessTracker.API.Models.Results
{
    public class ExerciseGroupSummaryPeriod
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public IEnumerable<ExerciseGroupSummary> Summaries { get; set; }
    }
}
