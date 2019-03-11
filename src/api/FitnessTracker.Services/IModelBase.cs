using System;

namespace FitnessTracker.Services
{
    public interface IModelBase
    {
        Guid Id { get; set; }

        DateTime Recorded { get; set; }
    }
}
