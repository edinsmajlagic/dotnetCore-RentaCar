using System.Collections.Generic;
using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using CarHireRC.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarHireRC.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _service;
        public KorisnikController(IKorisnikService service)
        {
            _service = service;
        }

        //Može se i ukloniti [Authorize]
        [Authorize(Roles = "Administrator,Menadžer,Uposlenik")]
        [HttpGet]
        public List<Korisnici> Get([FromQuery]KorisniciSearchRequest request)
        {
            return _service.Get(request);
        }

        //Može se i ukloniti [Authorize]
        [Authorize(Roles = "Administrator,Menadžer,Uposlenik")]
        [HttpPost]
        public Korisnici Insert(KorisniciUpsertRequest request)
        {
            return _service.Insert(request);
        }

        //Može se i ukloniti [Authorize]
        [Authorize(Roles = "Administrator,Menadžer,Uposlenik")]
        [HttpPut("{id}")]
        public Model.Models.Korisnici Update(int id, [FromBody]KorisniciUpsertRequest request)
        {
            var r= _service.Update(id, request);

            return r;
        }

        //Može se i ukloniti [Authorize]
        [Authorize(Roles = "Administrator,Menadžer,Uposlenik")]
        [HttpGet("{id}")]
        public Model.Models.Korisnici GetById(int id)
        {
            return _service.GetById(id);
        }
      
    }
}