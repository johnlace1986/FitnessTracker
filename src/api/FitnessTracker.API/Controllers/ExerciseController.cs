using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FitnessTracker.API.Models.Requests;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using FitnessTracker.MongoDB.Exercise;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("FitnessTracker.Web")]
    public class ExerciseController : FitnessTrackerControllerBase<Exercise, ExerciseRequest>
    {
        public ExerciseController(IFitnessTrackerContext context)
            : base(context)
        {
        }

        protected override IClient<Exercise> GetClient(IFitnessTrackerContext context)
        {
            return context.ExerciseClient;
        }

        [HttpGet]
        [Route("{id}", Name = "GetExerciseById")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            return EnsureModelNotNull(await Client.GetByIdAsync(id, cancellationToken).ConfigureAwait(false));
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] ExerciseRequest request, CancellationToken cancellationToken)
        {
            return Post(request, "GetExerciseById", cancellationToken);
        }
    }
}