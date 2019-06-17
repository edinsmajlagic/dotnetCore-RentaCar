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

    public class RacunController : BaseCRUDController<Model.Models.Racun, Model.Requests.RacunSearchRequest, Model.Requests.RacunUpsertRequest, Model.Requests.RacunUpsertRequest>
    {
        public RacunController(ICRUDService<Racun, RacunSearchRequest, RacunUpsertRequest, RacunUpsertRequest> service) : base(service)
        {
        }
    }
}