using System.Threading.Tasks;
using ClinicsAPI.IRepository;
using ClinicsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ClinicsAPI.IRepository;

namespace ClinicsAPI.Controllers
{
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        private readonly IPatentRepository _patentRepository;

        public SystemController(IPatentRepository patentRepository)
        {
            _patentRepository = patentRepository;
        }
        // Call an initialization - api/system/init
        [HttpGet("{setting}")]
        public string Get(string setting)
        {
            if (setting == "init")
            {
                _patentRepository.RemoveAll();
                _patentRepository.Add(new Patient()
                {
                    Id = "1",
                    FullName = "Mohammad Bitar",
                    PhoneNumber = "05313611777",
                    Notes = "Something wrong with me!!!"
                });
                _patentRepository.Add(new Patient()
                {
                    Id = "2",
                    FullName = "Salim Bitar",
                    PhoneNumber = "05313611888",
                    Notes = "Something wrong with me again!!!"
                });

                return "Done";
            }

            return "Unknown";
        }

    }
}
