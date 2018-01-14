using System.Threading.Tasks;
using ClinicsAPI.IRepository;
using ClinicsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicsAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Appointment")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<string> Get()
        {
            var appointments = await _appointmentRepository.Get();
            return JsonConvert.SerializeObject(appointments);
        }

        // GET: api/Doctor/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<string> Get(string id)
        {
            var appointment = await _appointmentRepository.Get(id) ?? new Appointment();
            return JsonConvert.SerializeObject(appointment);
        }

        // POST: api/Doctor
        [HttpPost]
        public void Post([FromBody]Appointment appointment)
        {
            _appointmentRepository.Add(appointment);
        }

        // PUT: api/Doctor/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Appointment appointment)
        {
            _appointmentRepository.Update(id, appointment);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _appointmentRepository.Remove(id);
        }

        [HttpDelete]
        public void DeleteAll()
        {
            _appointmentRepository.RemoveAll();
        }
    }
}
