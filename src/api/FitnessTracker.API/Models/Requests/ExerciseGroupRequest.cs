using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Models;
using FitnessTracker.Services;

namespace FitnessTracker.API.Models.Requests
{
    public class ExerciseGroupRequest : IRequest<ExerciseGroup>
    {
        public DateTime Recorded { get; set; }

        public double Weight { get; set; }

        public ExerciseGroup Map()
        {
            return new ExerciseGroup
            {
                Id = Guid.NewGuid(),
                Recorded = Recorded,
                Weight = Weight
            };
        }
    }
}
