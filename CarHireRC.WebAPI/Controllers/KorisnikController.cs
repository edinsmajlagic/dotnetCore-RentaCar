using System.Collections.Generic;
using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using CarHireRC.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarHireRC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _service;
        public KorisnikController(IKorisnikService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Korisnici> Get([FromQuery]KorisniciSearchRequest request)
        {
            return _service.Get(request);
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        public Korisnici Insert(KorisniciUpsertRequest request)
        {
            return _service.Insert(request);
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public Model.Models.Korisnici Update(int id, [FromBody]KorisniciUpsertRequest request)
        {
            var r= _service.Update(id, request);

            return r;
        }

        [HttpGet("{id}")]
        public Model.Models.Korisnici GetById(int id)
        {
            return _service.GetById(id);
        }
      
    }
}