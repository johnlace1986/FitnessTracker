using EnsureThat;
using FitnessTracker.MongoDB.Exercise;
using FitnessTracker.MongoDB.ExerciseGroup;
using FitnessTracker.Services;
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
            ExerciseClient = new ExerciseClient(database);
        }

        public IExerciseGroupClient ExerciseGroupClient { get; }

        public IExerciseClient ExerciseClient { get; }
    }
}
