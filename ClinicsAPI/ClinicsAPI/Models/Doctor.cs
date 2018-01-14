using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClinicsAPI.Models
{
    public class Doctor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FullNmae { get; set; }
        public string PhoneNumber { get; set; }
    }
}
