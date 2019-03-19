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
        private readonly IExerciseGroupSummaryAdapter _summaryAdapter;
        private readonly IExerciseGroupResultAdapter _resultAdapter;

        public ExerciseGroupController(
            IFitnessTrackerContext context,
            IExerciseGroupSummaryAdapter summaryAdapter,
            IExerciseGroupResultAdapter resultAdapter)
            : base(context)
        {
            Ensure.That(summaryAdapter).IsNotNull();
            Ensure.That(resultAdapter).IsNotNull();

            _summaryAdapter = summaryAdapter;
            _resultAdapter = resultAdapter;
        }

        protected override IExerciseGroupClient GetClient(IFitnessTrackerContext context)
        {
            return context.ExerciseGroupClient;
        }

        public override async Task<IActionResult> Get(int? limit, int? offset, CancellationToken cancellationToken)
        {
            var summaries = await _summaryAdapter.AdaptAsync(
                await Client.GetAsync(limit, offset, cancellationToken).ConfigureAwait(false),
                await Client.GetFirstExerciseGroup(cancellationToken).ConfigureAwait(false),
                cancellationToken).ConfigureAwait(false);

            var summaryGroups =
                from summary in summaries
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
            var result = await _resultAdapter.AdaptAsync(group, first, cancellationToken).ConfigureAwait(false);

            return Ok(result);
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