using CarHireRC.Model.Requests;
using CarHireRC.WebAPI.Services;

namespace CarHireRC.WebAPI.Controllers
{

    public class GradController : BaseController<Model.Models.Grad, GradSearchRequest>
    {
        public GradController(IService<Model.Models.Grad, GradSearchRequest> service) : base(service)
        {
        }
    }
}