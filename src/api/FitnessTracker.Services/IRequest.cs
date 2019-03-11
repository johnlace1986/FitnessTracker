using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Services
{
    public interface IRequest<out TModel> where TModel : IModel
    {
        TModel Map();
    }
}
