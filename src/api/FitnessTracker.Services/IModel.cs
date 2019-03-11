using System;

namespace FitnessTracker.Services
{
    public interface IModel
    {
        Guid Id { get; set; }

        DateTime Recorded { get; set; }
    }
}
