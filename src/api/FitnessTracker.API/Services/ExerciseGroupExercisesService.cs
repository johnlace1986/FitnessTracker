using EnsureThat;
using FitnessTracker.API.Models.Results;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using FitnessTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.API.Services
{
    public class ExerciseGroupExercisesService : IExerciseGroupExercisesService
    {
        private readonly IFitnessTrackerContext _context;
        public ExerciseGroupExercisesService(IFitnessTrackerContext context)
        {
            Ensure.That(context).IsNotNull();

            _context = context;
        }

        public IEnumerable<IResult> Map(IEnumerable<ExerciseGroup> groups)
        {
            var exercises = _context.ExerciseClient.Get().ToArray();

            return groups
                .Select((group, index) =>
                {
                    var minDate = index == 0 ? DateTime.MinValue : exercises[index - 1].Recorded;
                    var groupExercises = exercises.Where(exercise =>
                        exercise.Recorded > minDate && exercise.Recorded < group.Recorded);

                    return new ExerciseGroupResult
                    {
                        Id = group.Id,
                        Recorded = group.Recorded,
                        Weight = group.Weight,
                        Exercises = groupExercises
                    };
                });
        }

        public IResult Map(ExerciseGroup group)
        {
            return Map(new[] {group}).First();
        }
    }
}
