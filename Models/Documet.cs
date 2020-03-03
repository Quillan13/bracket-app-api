using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BracketApp.Api.Models
{
    public class Document
    {
        public Document()
        {
            
        }
        public Document(string ownerId)
        {
            OwnerId = ownerId;
            CreatedAt = DateTime.Now;
        }

        [BsonId]
        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [Required]
        public string OwnerId { get; set; }

        [Required]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}