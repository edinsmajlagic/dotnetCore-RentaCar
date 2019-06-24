using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using CarHireRC.WebAPI.Services;

namespace CarHireRC.WebAPI.Controllers
{

    public class AutomobilController : BaseCRUDController<Automobil, AutomobilSearchRequest, AutomobiliUPSERTtRequest, AutomobiliUPSERTtRequest>
    {
        public AutomobilController(ICRUDService<Automobil, AutomobilSearchRequest, AutomobiliUPSERTtRequest, AutomobiliUPSERTtRequest> service) : base(service)
        {
        }
    }
}