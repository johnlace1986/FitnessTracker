using FitnessTracker.Models;
using FitnessTracker.Services;
using System.Collections.Generic;

namespace FitnessTracker.API.Services
{
    public interface IExerciseGroupExercisesService
    {
        IEnumerable<IResult> Map(IEnumerable<ExerciseGroup> groups);

        IResult Map(ExerciseGroup group);
    }
}
