using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHireRC.WebAPI.Services
{
    public interface IKorisnikService
    {
        List<Model.Models.Korisnici> Get(KorisniciSearchRequest request);
        Model.Models.Korisnici GetById(int Id);
        Model.Models.Korisnici Update(int Id,KorisniciUpsertRequest request);
        Model.Models.Korisnici Insert(KorisniciUpsertRequest request);
        Model.Models.Korisnici Autentificiraj(string username,string password);

    }
}
