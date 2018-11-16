using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractitionerController : ControllerBase
    {
        private readonly PractitionerRepository practitionerRepository;

        public PractitionerController()
        {
            practitionerRepository = new PractitionerRepository();
        }

        [HttpGet]
        public ActionResult<List<Practitioner>> GetAll()
        {
            return practitionerRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetPractitioners")]
        public ActionResult<Practitioner> GetById(int id)
        {
            var item = practitionerRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }




    }
}