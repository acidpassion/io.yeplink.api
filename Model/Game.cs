using System;
using MongoDB.Bson.Serialization.Attributes;
namespace YeplinkAppApi.Model
{
    public class Game
    {
        [BsonId]
        public string Id { get; set; } 
        public string date { get; set; }
        public string type { get; set; }
        public string time { get; set; }
        public string time_elapsed { get; set; }
        public string host { get; set; }
        public string guest { get; set; }
        public string index1 { get; set; }
        public string pankou { get; set; }
        public string index2 { get; set; }
        public string gameId { get; set; }
    }
}
