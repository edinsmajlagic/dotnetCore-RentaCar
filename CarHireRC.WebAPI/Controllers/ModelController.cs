using CarHireRC.WebAPI.Services;
using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;

namespace CarHireRC.WebAPI.Controllers
{

    public class ModelController : BaseCRUDController<ModelAutomobila, Model.Requests.ModelAutomobilaSearch, Model.Requests.ModelAutomobilaUpsertRequest, Model.Requests.ModelAutomobilaUpsertRequest>
    {
        public ModelController(ICRUDService<ModelAutomobila, ModelAutomobilaSearch, ModelAutomobilaUpsertRequest, ModelAutomobilaUpsertRequest> service) : base(service)
        {
        }
    }
}