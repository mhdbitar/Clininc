using System.Threading.Tasks;
using ClinicsAPI.IRepository;
using ClinicsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicsAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Patient")]
    public class PatientController : Controller
    {
        private readonly IPatentRepository _patentRepository;

        public PatientController (IPatentRepository patentRepository)
        {
            _patentRepository = patentRepository;
        }

        // GET: api/Patient
        [HttpGet]
        public async Task<string> Get()
        {
            var patients = await _patentRepository.Get();
            return JsonConvert.SerializeObject(patients);
        }

        // GET: api/Patient/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<string> Get(string id)
        {
            var patient = await _patentRepository.Get(id) ?? new Patient();
            return JsonConvert.SerializeObject(patient);
        }
        
        // POST: api/Patient
        [HttpPost]
        public void Post([FromBody]Patient patient)
        {
            _patentRepository.Add(patient);
        }
        
        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Patient patient)
        {
            _patentRepository.Update(id, patient);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _patentRepository.Remove(id);
        }

        [HttpDelete]
        public void DeleteAll()
        {
            _patentRepository.RemoveAll();
        }
    }
}
