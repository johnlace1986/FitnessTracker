using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Models
{
    public abstract class ModelBase
    {
        public Guid Id { get; set; }

        public DateTime Recorded { get; set; }
    }
}
