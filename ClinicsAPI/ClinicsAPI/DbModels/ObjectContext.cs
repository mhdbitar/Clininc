using ClinicsAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ClinicsAPI.DbModels
{
    public class ObjectContext
    {
        private IMongoDatabase _database = null;

        public ObjectContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        // Database Tables
        public IMongoCollection<Patient> Patients
        {
            get
            {
                return _database.GetCollection<Patient>("Patient");
            }
        }

        public IMongoCollection<Doctor> Doctors
        {
            get
            {
                return _database.GetCollection<Doctor>("Doctor");
            }
        }

        public IMongoCollection<Appointment> Appointments
        {
            get
            {
                return _database.GetCollection<Appointment>("Appointment");
            }
        }
    }
}
