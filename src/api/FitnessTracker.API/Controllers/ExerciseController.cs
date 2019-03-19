using FitnessTracker.API.Models.Requests;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using FitnessTracker.MongoDB.Exercise;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("FitnessTracker.Web")]
    public class ExerciseController : FitnessTrackerControllerBase<Exercise, ExerciseRequest, IExerciseClient>
    {
        public ExerciseController(IFitnessTrackerContext context)
            : base(context)
        {
        }

        protected override IExerciseClient GetClient(IFitnessTrackerContext context)
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