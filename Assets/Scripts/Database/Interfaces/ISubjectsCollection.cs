using Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Database.Interfaces
{
    public interface ISubjectsCollection
    {
        IMongoCollection<School> Collection { get; }
    }
}
