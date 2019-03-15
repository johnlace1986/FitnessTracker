using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using FitnessTracker.API.Models.Requests;
using FitnessTracker.API.Services;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("FitnessTracker.Web")]
    public class ExerciseGroupController : FitnessTrackerControllerBase<ExerciseGroup, ExerciseGroupRequest>
    {
        private readonly IExerciseGroupExercisesService _exerciseGroupExercisesService;

        public ExerciseGroupController(
            IFitnessTrackerContext context,
            IExerciseGroupExercisesService exerciseGroupExercisesService)
            : base(context)
        {
            Ensure.That(exerciseGroupExercisesService).IsNotNull();

            _exerciseGroupExercisesService = exerciseGroupExercisesService;
        }

        protected override IClient<ExerciseGroup> GetClient(IFitnessTrackerContext context)
        {
            return context.ExerciseGroupClient;
        }

        protected override IEnumerable<IResult> MapToResults(IEnumerable<ExerciseGroup> models)
        {
            return _exerciseGroupExercisesService.Map(models);
        }

        protected override IResult MapToResult(ExerciseGroup model)
        {
            return _exerciseGroupExercisesService.Map(model);
        }

        [HttpGet]
        [Route("{id}", Name = "GetExerciseGroupById")]
        public override Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            return base.Get(id, cancellationToken);
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] ExerciseGroupRequest request, CancellationToken cancellationToken)
        {
            return Post(request, "GetExerciseGroupById", cancellationToken);
        }
    }
}