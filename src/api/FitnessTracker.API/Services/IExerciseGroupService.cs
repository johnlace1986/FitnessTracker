using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using FitnessTracker.API.Models.Results;
using FitnessTracker.Models;

namespace FitnessTracker.API.Services
{
    public interface IExerciseGroupService
    {
        Task<ExerciseGroupResult> Map(ExerciseGroup group, CancellationToken cancellationToken);
    }
}
