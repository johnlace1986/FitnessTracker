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
using FitnessTracker.MongoDB.ExerciseGroup;

namespace FitnessTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("FitnessTracker.Web")]
    public class ExerciseGroupController : FitnessTrackerControllerBase<ExerciseGroup, ExerciseGroupRequest, IExerciseGroupClient>
    {
        private readonly IExerciseGroupResultAdapter _service;

        public ExerciseGroupController(
            IFitnessTrackerContext context,
            IExerciseGroupResultAdapter service)
            : base(context)
        {
            Ensure.That(service).IsNotNull();

            _service = service;
        }

        protected override IExerciseGroupClient GetClient(IFitnessTrackerContext context)
        {
            return context.ExerciseGroupClient;
        }

        public override async Task<IActionResult> Get(int? limit, int? offset, CancellationToken cancellationToken)
        {
            var groups = await Client.GetAsync(limit, offset, cancellationToken).ConfigureAwait(false);

            var mapped = await Task.WhenAll(groups.Select(async (group) =>
            {
                var first = await GetInitialExerciseGroup(cancellationToken).ConfigureAwait(false);
                var result = await _service.AdaptAsync(group, first, cancellationToken).ConfigureAwait(false);

                return new
                {
                    result.Id,
                    result.Recorded,
                    result.Weight,
                    result.CanDelete,
                    result.TotalTimeDieting,
                    result.WeightLostThisWeek,
                    result.WeightLostInTotal,
                    result.WeightLosingPerWeek,
                    result.TotalExerciseDistance,
                    result.TotalTimeSpentExercising,
                    ExerciseCount = result.Exercises.Count()
                };
            })).ConfigureAwait(false);

            var summaryGroups =
                from summary in mapped
                group summary by new {summary.Recorded.Year, Month = summary.Recorded.ToString("MMMM")}
                into summaryGroup
                select new { summaryGroup.Key.Year, summaryGroup.Key.Month, Groups = summaryGroup.AsEnumerable() };

            return Ok(summaryGroups);
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

            var first = await GetInitialExerciseGroup(cancellationToken).ConfigureAwait(false);
            var result = await _service.AdaptAsync(group, first, cancellationToken).ConfigureAwait(false);

            return Ok(new
            {
                result.Id,
                result.Recorded,
                result.Weight,
                result.CanDelete,
                result.TotalTimeDieting,
                result.WeightLostThisWeek,
                result.WeightLostInTotal,
                result.WeightLosingPerWeek,
                result.TotalExerciseDistance,
                result.TotalTimeSpentExercising,
                result.Exercises
            });
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] ExerciseGroupRequest request, CancellationToken cancellationToken)
        {
            return Post(request, "GetExerciseGroupById", cancellationToken);
        }

        private Task<ExerciseGroup> GetInitialExerciseGroup(CancellationToken cancellationToken)
        {
            return Client.GetFirstExerciseGroup(cancellationToken);

        }
    }
}