using ClinicsAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicsAPI.IRepository
{
    public interface IPatentRepository
    {
        // Get all the patients from Database
        Task<IEnumerable<Patient>> Get();

        // Get a single patient from Databse by using his Id
        Task<Patient> Get(string id);

        // Add new Patient
        Task Add(Patient patient);

        // Update a patient
        Task<bool> Update(string id, Patient patient);

        // Remove a patient by his Id
        Task<bool> Remove(string id);

        // Remove all the pateints
        Task<bool> RemoveAll();
    }
}
