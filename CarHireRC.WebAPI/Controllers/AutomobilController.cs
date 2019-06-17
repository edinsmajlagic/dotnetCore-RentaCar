using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using CarHireRC.WebAPI.Services;

namespace CarHireRC.WebAPI.Controllers
{

    public class AutomobilController : BaseCRUDController<Automobil, RezervacijaSearchRequest, AutomobiliUPSERTtRequest, AutomobiliUPSERTtRequest>
    {
        public AutomobilController(ICRUDService<Automobil, RezervacijaSearchRequest, AutomobiliUPSERTtRequest, AutomobiliUPSERTtRequest> service) : base(service)
        {
        }
    }
}