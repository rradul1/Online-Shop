using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebApplication2.Models
{
    public class UserAdd
    {

        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Varsta { get; set; }
        public string Adresa { get; set; }
        public string Parola { get; set; }
        public string ConfParola { get; set; }

    }
}