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
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ObjectContext _context = null; 

        public AppointmentRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public async Task Add(Appointment appointment)
        {
            try
            {
                await _context.Appointments.InsertOneAsync(appointment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
         }

        public async Task<IEnumerable<Appointment>> Get()
        {
            try
            {
                return await _context.Appointments.Find(x => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Appointment> Get(string id)
        {
            var filter = Builders<Appointment>.Filter.Eq("Id", id);
            try
            {
                return await _context.Appointments.Find(filter).FirstOrDefaultAsync();
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
                DeleteResult actionResult = await _context.Appointments.DeleteOneAsync(Builders<Appointment>.Filter.Eq("Id", id));

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
                DeleteResult actionResult = await _context.Appointments.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> Update(string id, Appointment appointment)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Appointments.ReplaceOneAsync(n => n.Id.Equals(id), appointment, new UpdateOptions { IsUpsert = true });

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
