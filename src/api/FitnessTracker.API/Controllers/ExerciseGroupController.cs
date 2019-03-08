using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using FitnessTracker.API.Models;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using FitnessTracker.MongoDB.ExerciseGroup;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("FitnessTracker.Web")]
    public class ExerciseGroupController : FitnessTrackerControllerBase<ExerciseGroup, IExerciseGroupClient, ExerciseGroupDto>
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
        public override Task<IEnumerable<ExerciseGroup>> Get(CancellationToken cancellationToken)
        {
            return base.Get(cancellationToken);
        }

        [HttpDelete("{id}")]
        public override Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            return base.Delete(id, cancellationToken);
        }

        [HttpPost]
        public override async Task<IActionResult> Post([FromBody] ExerciseGroupDto exerciseGroup, CancellationToken cancellationToken)
        {
            if (exerciseGroup == null)
            {
                return BadRequest();
            }

            //TODO return CreatedAtRoute
            return Ok(await Client.InsertAsync(exerciseGroup.Recorded, exerciseGroup.Weight, cancellationToken));
        }
    }
}