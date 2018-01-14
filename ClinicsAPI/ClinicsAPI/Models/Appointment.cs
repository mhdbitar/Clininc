using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ClinicsAPI.Models
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public ObjectId PatientId { get; set; }
        public ObjectId DoctorId { get; set; }
        public ObjectId ParentId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsReview { get; set; }
    }
}
