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
    public class ExerciseGroupController : ControllerBase
    {
        private readonly IExerciseGroupClient _client;

        public ExerciseGroupController(IFitnessTrackerContext context)
        {
            Ensure.That(context).IsNotNull();

            _client = context.ExerciseGroupClient;
        }

        [HttpGet]
        public IEnumerable<ExerciseGroup> Get(CancellationToken cancellation)
        {
            return _client.Get();
        }

        [HttpPost]
        public Task<ExerciseGroup> Post([FromBody] ExerciseGroupDto exerciseGroup, CancellationToken cancellationToken)
        {
            //TODO return CreatedAtRoute
            return _client.InsertAsync(exerciseGroup.Recorded, exerciseGroup.Weight, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _client.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}