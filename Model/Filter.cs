using System;
using MongoDB.Bson.Serialization.Attributes;

namespace NotebookAppApi.Model
{
    public class Filter
    {
        [BsonId]
        public string Id { get; set; } 
        public decimal EuroAsiaGuestTo { get; set; }
        public decimal EuroAsiaGuestFrom { get; set; }
        public string EuroAsiaPanko { get; set; }
        public decimal EuroAsiaHostTo { get; set; }
        public decimal EuroAsiaHostFrom { get; set; }
        public decimal EndGuestTo { get; set; }
        public decimal EndGuestFrom { get; set; }
        public string EndPanko { get; set; }
        public decimal EndHostTo { get; set; }
        public decimal EndHostFrom { get; set; }
        public decimal EowGuestTo { get; set; }
        public decimal EowGuestFrom { get; set; }
        public string NowPanko { get; set; }
        public decimal NowHostTo { get; set; }
        public decimal NowHostFrom { get; set; }
        public decimal NowGuestTo { get; set; }
        public decimal NowGuestFrom { get; set; }
        public decimal StartGuestTo { get; set; }
        public decimal StartGuestFrom { get; set; }
        public string StartPanko { get; set; }
        public decimal StartHostTo { get; set; }
        public decimal StartHostFrom { get; set; }
        public string Description { get; set; }
        public bool Activated { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
