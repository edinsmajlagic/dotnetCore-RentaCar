using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using CarHireRC.WebAPI.Services;

namespace CarHireRC.WebAPI.Controllers
{

    public class KlijentController : BaseCRUDController<Model.Models.Klijent, Model.Requests.KlijentSearchRequest, Model.Requests.KlijentUpsertRequest, Model.Requests.KlijentUpsertRequest>
    {
        public KlijentController(ICRUDService<Klijent, KlijentSearchRequest, KlijentUpsertRequest, KlijentUpsertRequest> service) : base(service)
        {
        }
    }
}