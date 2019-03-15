using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using FitnessTracker.API.Models.Requests;
using FitnessTracker.API.Models.Results;
using FitnessTracker.API.Services;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using FitnessTracker.MongoDB.ExerciseGroup;
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

        [HttpGet]
        [Route("{id}", Name = "GetExerciseGroupById")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var group = await Client.GetById(id, cancellationToken);

            if (group == null)
            {
                return NotFound();
            }

            return Ok(await _service.Map(group, cancellationToken));
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] ExerciseGroupRequest request, CancellationToken cancellationToken)
        {
            return Post(request, "GetExerciseGroupById", cancellationToken);
        }
    }
}