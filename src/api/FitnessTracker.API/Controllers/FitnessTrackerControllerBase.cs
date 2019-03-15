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

        protected abstract IEnumerable<IResult> MapToResults(IEnumerable<TModel> models);

        [HttpGet]
        public IActionResult Get()
        {
            var models = Client.Get();
            var mapped = MapToResults(models);
            return Ok(mapped);
        }

        protected abstract IResult MapToResult(TModel model);

        public virtual async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var model = await Client.GetById(id, cancellationToken);

            if (model == null)
            {
                return NotFound();
            }

            var mapped = MapToResult(model);
            return Ok(mapped);
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
    }
}
