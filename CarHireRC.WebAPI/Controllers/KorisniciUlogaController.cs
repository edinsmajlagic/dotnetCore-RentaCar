using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using CarHireRC.WebAPI.Services;

namespace CarHireRC.WebAPI.Controllers
{

    public class KorisniciUlogaController : BaseController<Model.Models.KorisniciUloge, Model.Requests.KorisniciUlogeSearchRequest>
    {
        public KorisniciUlogaController(IService<KorisniciUloge, KorisniciUlogeSearchRequest> service) : base(service)
        {
        }
    }
}