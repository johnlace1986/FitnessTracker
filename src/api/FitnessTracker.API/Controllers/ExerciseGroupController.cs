using EnsureThat;
using FitnessTracker.API.Models.Requests;
using FitnessTracker.API.Services;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using FitnessTracker.MongoDB.ExerciseGroup;
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
    public class ExerciseGroupController : FitnessTrackerControllerBase<ExerciseGroup, ExerciseGroupRequest, IExerciseGroupClient>
    {
        private readonly IExerciseGroupSummaryAdapter _summaryAdapter;
        private readonly IExerciseGroupResultAdapter _resultAdapter;
        private readonly IExerciseGroupSummaryPeriodAdapter _summaryPeriodAdapter;

        public ExerciseGroupController(
            IFitnessTrackerContext context,
            IExerciseGroupSummaryAdapter summaryAdapter,
            IExerciseGroupResultAdapter resultAdapter,
            IExerciseGroupSummaryPeriodAdapter summaryPeriodAdapter)
            : base(context)
        {
            Ensure.That(summaryAdapter).IsNotNull();
            Ensure.That(resultAdapter).IsNotNull();
            Ensure.That(summaryPeriodAdapter).IsNotNull();

            _summaryAdapter = summaryAdapter;
            _resultAdapter = resultAdapter;
            _summaryPeriodAdapter = summaryPeriodAdapter;
        }

        protected override IExerciseGroupClient GetClient(IFitnessTrackerContext context)
        {
            return context.ExerciseGroupClient;
        }

        public override async Task<IActionResult> Get(int? limit, int? offset, CancellationToken cancellationToken)
        {
            var summaries = await _summaryAdapter.AdaptAsync(
                await Client.GetAsync(limit, offset, cancellationToken).ConfigureAwait(false),
                await GetInitialExerciseGroup(cancellationToken).ConfigureAwait(false),
                cancellationToken).ConfigureAwait(false);

            return Ok(_summaryPeriodAdapter.Adapt(summaries));
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