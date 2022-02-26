using Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Database.Interfaces
{
    public interface IDatabaseConnection
    {
        Base.Database Connect();
    }
}
