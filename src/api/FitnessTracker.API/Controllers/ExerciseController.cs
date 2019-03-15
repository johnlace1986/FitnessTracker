﻿using FitnessTracker.API.Models.Requests;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitnessTracker.API.Models.Results;

namespace FitnessTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("FitnessTracker.Web")]
    public class ExerciseController : FitnessTrackerControllerBase<Exercise, ExerciseRequest>
    {
        public ExerciseController(IFitnessTrackerContext context)
            : base(context)
        {
        }

        protected override IClient<Exercise> GetClient(IFitnessTrackerContext context)
        {
            return context.ExerciseClient;
        }

        protected override IEnumerable<IResult> MapToResults(IEnumerable<Exercise> models)
        {
            return models;
        }

        protected override IResult MapToResult(Exercise model)
        {
            return model;
        }

        [HttpGet]
        [Route("{id}", Name = "GetExerciseById")]
        public override Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            return base.Get(id, cancellationToken);
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] ExerciseRequest request, CancellationToken cancellationToken)
        {
            return Post(request, "GetExerciseById", cancellationToken);
        }
    }
}