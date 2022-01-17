using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebApplication2.Models
{
    public class Login
    {

        [BsonRepresentation(BsonType.ObjectId)]

        public string Email { get; set; }
        public string Parola { get; set; }

    }
}