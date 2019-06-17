using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using CarHireRC.WebAPI.Services;

namespace CarHireRC.WebAPI.Controllers
{

    public class DrzavaController : BaseController<Model.Models.Drzava, Model.Requests.DrzavaSearchRequest>
    {
        public DrzavaController(IService<Drzava, DrzavaSearchRequest> service) : base(service)
        {
        }
    }
}