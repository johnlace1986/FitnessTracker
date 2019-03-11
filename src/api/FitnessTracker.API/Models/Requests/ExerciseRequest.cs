using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Models;
using FitnessTracker.Services;

namespace FitnessTracker.API.Models.Requests
{
    public class ExerciseRequest : IRequest<Exercise>
    {
        public DateTime Recorded { get; set; }

        public TimeSpan TimeTaken { get; set; }

        public double Distance { get; set; }

        public int CaloriesBurned { get; set; }

        public Exercise Map()
        {
            return new Exercise
            {
                Id = Guid.NewGuid(),
                Recorded = Recorded,
                TimeTaken = TimeTaken,
                Distance = Distance,
                CaloriesBurned = CaloriesBurned
            };
        }
    }
}
