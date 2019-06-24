using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHireRC.WebAPI.Services
{
    public interface IKlijentService
    {
        List<Model.Models.Klijent> Get(KlijentSearchRequest request);
        Model.Models.Klijent GetById(int Id);
        Model.Models.Klijent Update(int Id, KlijentUpsertRequest request);
        Model.Models.Klijent Insert(KlijentUpsertRequest request);
        Model.Models.Klijent Autentificiraj(string username, string password);
    }
}
