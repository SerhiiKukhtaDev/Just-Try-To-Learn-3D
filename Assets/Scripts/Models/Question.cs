using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Question
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }
        
        public string Name { get; set; }
        
        public List<Answer> Answers { get; set; }

        public void GenerateRandomPositions()
        {
            Answers = Answers.OrderBy(x => Guid.NewGuid().ToString()).ToList();
        }

        public string Difficulty { get; set; }
        
        public int TimeToAnswer { get; set; }
    }
}
