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
        public IEnumerable<Exercise> Get(CancellationToken cancellation)
        {
            return _client.Get();
        }

        [HttpPut]
        public Task<Exercise> Put([FromBody] ExerciseDto exercise, CancellationToken cancellationToken)
        {
            return _client.InsertAsync(exercise.Recorded, exercise.TimeTaken, exercise.Distance, exercise.CaloriesBurned, cancellationToken);
        }

        [HttpDelete("{id}")]
        public Task Delete(Guid id, CancellationToken cancellationToken)
        {
            return _client.DeleteAsync(id, cancellationToken);
        }
    }
}