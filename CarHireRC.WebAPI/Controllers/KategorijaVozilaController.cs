using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using CarHireRC.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarHireRC.WebAPI.Controllers
{

    public class KategorijaVozilaController : BaseController<Model.Models.KategorijaVozila, object>
    {
        public KategorijaVozilaController(IService<KategorijaVozila, object> service) : base(service)
        {
        }
    }
}