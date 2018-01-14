using ClinicsAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicsAPI.IRepository
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> Get();
        Task<Appointment> Get(string id);
        Task Add(Appointment appointment);
        Task<bool> Update(string id, Appointment appointment);
        Task<bool> Remove(string id);
        Task<bool> RemoveAll();
    }
}
