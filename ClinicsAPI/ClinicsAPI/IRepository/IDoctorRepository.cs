using ClinicsAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicsAPI.IRepository
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> Get();
        Task<Doctor> Get(string id);
        Task Add(Doctor doctor);
        Task<bool> Update(string id, Doctor doctor);
        Task<bool> Remove(string id);
        Task<bool> RemoveAll();
    }
}
