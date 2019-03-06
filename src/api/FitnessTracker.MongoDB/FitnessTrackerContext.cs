using System;
using System.Collections.Generic;
using System.Text;
using EnsureThat;
using FitnessTracker.MongoDB.ExerciseGroup;
using MongoDB.Driver;

namespace FitnessTracker.MongoDB
{
    public class FitnessTrackerContext : IFitnessTrackerContext
    {
        public FitnessTrackerContext(string connectionString, string databaseName)
        {
            Ensure.That(connectionString).IsNotNullOrWhiteSpace();
            Ensure.That(databaseName).IsNotNullOrWhiteSpace();

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            ExerciseGroupClient = new ExerciseGroupClient(database);
        }

        public IExerciseGroupClient ExerciseGroupClient { get; }
    }
}
