using EnsureThat;
using FitnessTracker.MongoDB;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.API.Controllers
{
    public abstract class FitnessTrackerControllerBase<TModel, TRequest, TClient> 
        : ControllerBase 
        where TModel : IModel
        where TRequest : IRequest<TModel>
        where TClient : IClient<TModel>
    {
        protected TClient Client { get; }

        protected FitnessTrackerControllerBase(IFitnessTrackerContext context)
        {
            Ensure.That(context).IsNotNull();

            Client = GetClient(context);
        }

        protected abstract TClient GetClient(IFitnessTrackerContext context);

        [HttpGet]
        public virtual async Task<IActionResult> Get(int? limit, int? offset, CancellationToken cancellationToken)
        {
            var models = await Client.GetAsync(limit, offset, cancellationToken).ConfigureAwait(false);
            return Ok(models);
        }

        protected async Task<IActionResult> Post(TRequest request, string routeName, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var model = await Client.InsertAsync(request, cancellationToken).ConfigureAwait(false);
            return CreatedAtRoute(routeName, new { model.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var model = await Client.GetByIdAsync(id, cancellationToken).ConfigureAwait(false);

            if (model == null)
            {
                return NotFound();
            }

            await Client.DeleteAsync(id, cancellationToken).ConfigureAwait(false);
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
