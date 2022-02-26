using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class School : Model<Subject>
    {
        
    }

    public class Model<TItem>
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }
        
        public string Name { get; set; }
        
        public List<TItem> Items { get; set; }
    }
}
