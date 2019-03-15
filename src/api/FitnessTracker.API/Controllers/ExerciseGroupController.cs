using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FitnessTracker.API.Models.Requests;
using FitnessTracker.API.Models.Results;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using FitnessTracker.MongoDB.ExerciseGroup;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("FitnessTracker.Web")]
    public class ExerciseGroupController : FitnessTrackerControllerBase<ExerciseGroup, IExerciseGroupClient, ExerciseGroupRequest>
    {
        public ExerciseGroupController(IFitnessTrackerContext context)
            : base(context)
        {
        }

        protected override IExerciseGroupClient GetClient(IFitnessTrackerContext context)
        {
            return context.ExerciseGroupClient;
        }

        [HttpGet]
        [Route("{id}", Name = "GetExerciseGroupById")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var group = await Client.GetById(id, cancellationToken);

            if (group == null)
            {
                return NotFound();
            }

            var previous = await Client.GetPreviousExerciseGroupById(group.Recorded, cancellationToken);

            var exercises = await Context.ExerciseClient.GetExercisesInDateRange(previous?.Recorded ?? DateTime.MinValue, group.Recorded);

            return Ok(new ExerciseGroupResult
            {
                Id = group.Id,
                Recorded = group.Recorded,
                Weight = group.Weight,
                Exercises = exercises
            });
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] ExerciseGroupRequest request, CancellationToken cancellationToken)
        {
            return Post(request, "GetExerciseGroupById", cancellationToken);
        }
    }
}