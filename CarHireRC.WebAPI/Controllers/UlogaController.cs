using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarHireRC.Model.Models;
using CarHireRC.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarHireRC.WebAPI.Controllers
{

    public class UlogaController : BaseController<Model.Models.Uloge, object>
    {
        public UlogaController(IService<Uloge, object> service) : base(service)
        {
        }
    }
}