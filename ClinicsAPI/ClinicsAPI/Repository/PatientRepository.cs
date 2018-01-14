using ClinicsAPI.DbModels;
using ClinicsAPI.IRepository;
using ClinicsAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicsAPI.Repository
{
    public class PatientRepository : IPatentRepository
    {
        private readonly ObjectContext _context = null;

        public PatientRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public async Task Add(Patient patient)
        {
            try
            {
                await _context.Patients.InsertOneAsync(patient);
            }
            catch (Exception ex)
            {
                // log or manage the await _context.Patients.InsertOneAsync(patient);
                throw ex;
            }
        }

        public async Task<IEnumerable<Patient>> Get()
        {
            try
            {
                return await _context.Patients.Find(x => true).ToListAsync();
            } 
            catch (Exception ex)
            {
                // log or manage the await _context.Patients.InsertOneAsync(patient);
                throw ex;
            }
        }

        public async Task<Patient> Get(string id)
        {
            var filter = Builders<Patient>.Filter.Eq("Id", id);
            try
            {
                return await _context.Patients.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
       
        public async Task<bool> Remove(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Patients.DeleteOneAsync(Builders<Patient>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveAll()
        {
            try
            {
                DeleteResult actionResult = await _context.Patients.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            } 
        }

        public async Task<bool> Update(string id, Patient patient)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Patients.ReplaceOneAsync(n => n.Id.Equals(id), patient, new UpdateOptions { IsUpsert = true });

                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
