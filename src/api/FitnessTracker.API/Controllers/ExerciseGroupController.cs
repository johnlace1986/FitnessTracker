using EnsureThat;
using FitnessTracker.API.Models.Requests;
using FitnessTracker.API.Models.Results;
using FitnessTracker.API.Services;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("FitnessTracker.Web")]
    public class ExerciseGroupController : FitnessTrackerControllerBase<ExerciseGroup, ExerciseGroupRequest>
    {
        private readonly IExerciseGroupService _service;

        public ExerciseGroupController(
            IFitnessTrackerContext context,
            IExerciseGroupService service)
            : base(context)
        {
            Ensure.That(service).IsNotNull();

            _service = service;
        }

        protected override IClient<ExerciseGroup> GetClient(IFitnessTrackerContext context)
        {
            return context.ExerciseGroupClient;
        }

        public override async Task<IActionResult> Get(int? limit, int? offset, CancellationToken cancellationToken)
        {
            var groups = await Client.GetAsync(limit, offset, cancellationToken).ConfigureAwait(false);

            var mapped = await Task.WhenAll(groups.Select(async (group) =>
            {
                var exercises = await _service.GetExercisesAsync(group, cancellationToken).ConfigureAwait(false);

                return new ExerciseGroupSummary
                {
                    Id = group.Id,
                    Recorded = group.Recorded,
                    Weight = group.Weight,
                    ExerciseCount = exercises.Count()
                };
            })).ConfigureAwait(false);

            return Ok(mapped);
        }

        [HttpGet]
        [Route("{id}", Name = "GetExerciseGroupById")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var group = await Client.GetByIdAsync(id, cancellationToken).ConfigureAwait(false);

            if (group == null)
            {
                return NotFound();
            }

            var exercises = await _service.GetExercisesAsync(group, cancellationToken);

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