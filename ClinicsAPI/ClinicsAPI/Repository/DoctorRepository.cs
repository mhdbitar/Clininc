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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ObjectContext _context = null;

        public DoctorRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public async Task Add(Doctor doctor)
        {
            try
            {
                await _context.Doctors.InsertOneAsync(doctor);
            }
            catch (Exception ex)
            {
                // log or manage the await _context.Patients.InsertOneAsync(patient);
                throw ex;
            }
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            try
            {
                return await _context.Doctors.Find(x => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the await _context.Patients.InsertOneAsync(patient);
                throw ex;
            }
        }

        public async Task<Doctor> Get(string id)
        {
            var filter = Builders<Doctor>.Filter.Eq("Id", id);
            try
            {
                return await _context.Doctors.Find(filter).FirstOrDefaultAsync();
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
                DeleteResult actionResult = await _context.Doctors.DeleteOneAsync(Builders<Doctor>.Filter.Eq("Id", id));

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
                DeleteResult actionResult = await _context.Doctors.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> Update(string id, Doctor doctor)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Doctors.ReplaceOneAsync(n => n.Id.Equals(id), doctor, new UpdateOptions { IsUpsert = true });

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
