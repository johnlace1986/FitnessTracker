using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FitnessTracker.API.Models.Requests;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("FitnessTracker.Web")]
    public class ExerciseGroupController : FitnessTrackerControllerBase<ExerciseGroup, ExerciseGroupRequest>
    {
        public ExerciseGroupController(IFitnessTrackerContext context)
            : base(context)
        {
        }

        protected override IClient<ExerciseGroup> GetClient(IFitnessTrackerContext context)
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
        public override Task<IActionResult> Post([FromBody] ExerciseGroupRequest request, CancellationToken cancellationToken)
        {
            return base.Post(request, cancellationToken);
        }
    }
}