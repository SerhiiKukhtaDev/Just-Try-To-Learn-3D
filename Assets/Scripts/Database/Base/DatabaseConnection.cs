using Database.Constants;
using Database.Interfaces;
using Models;
using MongoDB.Driver;

namespace Database.Base
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private IMongoDatabase _database;
        private IMongoCollection<School> _collection;

        public Database Connect()
        {
            var client = new MongoClient(DatabaseConstants.DatabaseConnection);
            
            _database = client.GetDatabase(DatabaseConstants.DatabaseName);
            _collection = _database.GetCollection<School>(DatabaseConstants.DatabaseSubjectsCollectionName);

            return new Database(_database, _collection);
        }
    }
}
