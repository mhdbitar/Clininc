using System.Threading.Tasks;
using ClinicsAPI.IRepository;
using ClinicsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicsAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Doctor")]
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        // GET: api/Doctor
        [HttpGet]
        public async Task<string> Get()
        {
            var doctors = await _doctorRepository.Get();
            return JsonConvert.SerializeObject(doctors);
        }

        // GET: api/Doctor/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<string> Get(string id)
        {
            var doctor = await _doctorRepository.Get(id) ?? new Doctor();
            return JsonConvert.SerializeObject(doctor);
        }

        // POST: api/Doctor
        [HttpPost]
        public void Post([FromBody]Doctor doctor)
        {
            _doctorRepository.Add(doctor);
        }
        
        // PUT: api/Doctor/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Doctor doctor)
        {
            _doctorRepository.Update(id, doctor);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _doctorRepository.Remove(id);
        }

        [HttpDelete]
        public void DeleteAll()
        {
            _doctorRepository.RemoveAll();
        }
    }
}
