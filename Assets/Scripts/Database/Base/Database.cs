using Models;
using MongoDB.Driver;

namespace Database.Base
{
    public class Database
    {
        private IMongoDatabase _database;

        public IMongoCollection<School> SubjectsCollection { get; }

        public Database(IMongoDatabase database, IMongoCollection<School> subjectsCollection)
        {
            _database = database;
            SubjectsCollection = subjectsCollection;
        }
    }
}
