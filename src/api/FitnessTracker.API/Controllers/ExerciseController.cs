﻿using System;
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
    public class ExerciseController : FitnessTrackerControllerBase<Exercise, ExerciseRequest>
    {
        public ExerciseController(IFitnessTrackerContext context)
            :base(context)
        {
        }

        protected override IClient<Exercise> GetClient(IFitnessTrackerContext context)
        {
            return context.ExerciseClient;
        }

        [HttpGet]
        public override Task<IEnumerable<Exercise>> Get(CancellationToken cancellationToken)
        {
            return base.Get(cancellationToken);
        }

        [HttpDelete("{id}")]
        public override Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            return base.Delete(id, cancellationToken);
        }

        [HttpPost]
        public override Task<IActionResult> Post([FromBody] ExerciseRequest request, CancellationToken cancellationToken)
        {
            return base.Post(request, cancellationToken);
        }
    }
}