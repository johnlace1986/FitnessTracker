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
            return _client.GetExerciseGroups();
        }

        [HttpPut]
        public Task<ExerciseGroup> Put([FromBody] ExerciseGroupDto exerciseGroup, CancellationToken cancellationToken)
        {
            return _client.InsertAsync(exerciseGroup.Weight, exerciseGroup.Recorded, cancellationToken);
        }

        [HttpDelete("{id}")]
        public Task Delete(Guid id, CancellationToken cancellationToken)
        {
            return _client.DeleteAsync(id, cancellationToken);
        }
    }
}