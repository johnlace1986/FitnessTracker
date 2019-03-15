﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using FitnessTracker.API.Models;
using FitnessTracker.Models;
using FitnessTracker.MongoDB;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.API.Controllers
{
    public abstract class FitnessTrackerControllerBase<TModel, TClient, TRequest> 
        : ControllerBase 
        where TModel : IModel
        where TClient : IClient<TModel>
        where TRequest : IRequest<TModel>
    {
        protected IFitnessTrackerContext Context { get; }

        protected TClient Client { get; }

        protected FitnessTrackerControllerBase(IFitnessTrackerContext context)
        {
            Ensure.That(context).IsNotNull();

            Context = context;
            Client = GetClient(context);
        }

        protected abstract TClient GetClient(IFitnessTrackerContext context);

        [HttpGet]
        public Task<IEnumerable<TModel>> Get(CancellationToken cancellationToken)
        {
            return Task.FromResult(Client.Get());
        }

        protected async Task<IActionResult> Post(TRequest request, string routeName, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var model = await Client.InsertAsync(request, cancellationToken);
            return CreatedAtRoute(routeName, new { model.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var model = await Client.GetById(id, cancellationToken);

            if (model == null)
            {
                return NotFound();
            }

            await Client.DeleteAsync(id, cancellationToken);
            return Ok();
        }

        protected IActionResult EnsureModelNotNull(TModel model)
        {
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}
