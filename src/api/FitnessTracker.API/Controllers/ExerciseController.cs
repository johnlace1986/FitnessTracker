using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using FitnessTracker.API.Models;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using FitnessTracker.MongoDB.Exercise;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("FitnessTracker.Web")]
    public class ExerciseController : FitnessTrackerControllerBase<Exercise, IExerciseClient, ExerciseDto>
    {
        public ExerciseController(IFitnessTrackerContext context)
            :base(context)
        {
        }

        protected override IExerciseClient GetClient(IFitnessTrackerContext context)
        {
            return context.ExerciseClient;
        }

        [HttpGet]
        public override Task<IEnumerable<Exercise>> Get(CancellationToken cancellationToken)
        {
            return base.Get(cancellationToken);
        }

        [HttpDelete("{id}")]
        public override Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            return base.Delete(id, cancellationToken);
        }

        [HttpPost]
        public override async Task<IActionResult> Post([FromBody] ExerciseDto exerciseGroup, CancellationToken cancellationToken)
        {
            if (exerciseGroup == null)
            {
                return BadRequest();
            }

            //TODO return CreatedAtRoute
            return Ok(await Client.InsertAsync(exerciseGroup.Recorded, exerciseGroup.TimeTaken, exerciseGroup.Distance, exerciseGroup.CaloriesBurned, cancellationToken));
        }
    }
}