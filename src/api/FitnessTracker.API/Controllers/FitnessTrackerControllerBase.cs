using System;
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
    public abstract class FitnessTrackerControllerBase<TModel, TRequest> 
        : ControllerBase 
        where TModel : IModel
        where TRequest : IRequest<TModel>
    {
        private IClient<TModel> Client { get; }

        protected FitnessTrackerControllerBase(IFitnessTrackerContext context)
        {
            Ensure.That(context).IsNotNull();

            Client = GetClient(context);
        }

        protected abstract IClient<TModel> GetClient(IFitnessTrackerContext context);

        public virtual Task<IEnumerable<TModel>> Get(CancellationToken cancellationToken)
        {
            return Task.FromResult(Client.Get());
        }

        public virtual async Task<IActionResult> Post(TRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return BadRequest();
            }

            //TODO return CreatedAtRoute
            return Ok(await Client.InsertAsync(request, cancellationToken));
        }

        public virtual async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var model = await Client.GetById(id, cancellationToken);

            if (model == null)
            {
                return NotFound();
            }

            await Client.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
