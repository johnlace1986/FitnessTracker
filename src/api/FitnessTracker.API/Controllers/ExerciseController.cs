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
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseClient _client;

        public ExerciseController(IFitnessTrackerContext context)
        {
            Ensure.That(context).IsNotNull();

            _client = context.ExerciseClient;
        }

        [HttpGet]
        public Task<IEnumerable<Exercise>> Get(CancellationToken cancellation)
        {
            return Task.FromResult(_client.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExerciseDto exerciseGroup, CancellationToken cancellationToken)
        {
            if (exerciseGroup == null)
            {
                return BadRequest();
            }

            //TODO return CreatedAtRoute
            return Ok(await _client.InsertAsync(exerciseGroup.Recorded, exerciseGroup.TimeTaken, exerciseGroup.Distance, exerciseGroup.CaloriesBurned, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _client.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}