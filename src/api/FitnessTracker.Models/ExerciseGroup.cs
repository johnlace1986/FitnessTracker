﻿using FitnessTracker.Services;
using System;

namespace FitnessTracker.Models
{
    public class ExerciseGroup : IModel
    {
        public Guid Id { get; set; }

        public DateTime Recorded { get; set; }

        public double Weight { get; set; }
    }
}
