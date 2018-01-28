using System;
using MongoDB.Bson.Serialization.Attributes;
namespace YeplinkAppApi.Model
{
    public class GameDetail
    {
        [BsonId]
        public string Id { get; set; } 
        public string company { get; set; }
        public string panko { get; set; }
        public object startHost { get; set; }
        public object startPanko { get; set; }
        public object startGuest { get; set; }
        public object nowHost { get; set; }
        public object nowPanko { get; set; }
        public object nowGuest { get; set; }
        public object endHost { get; set; }
        public object endPanko { get; set; }
        public object endGuest { get; set; }
        public string euroAsiaHost { get; set; }
        public string euroAsiaPanko { get; set; }
        public string euroAsiaGuest { get; set; }
        public string euroAsiaTotal { get; set; }
        public string gameId { get; set; }
    }
}
