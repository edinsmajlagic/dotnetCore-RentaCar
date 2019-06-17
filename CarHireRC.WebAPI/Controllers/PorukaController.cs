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

    public class PorukaController : BaseCRUDController<Model.Models.Poruka, Model.Requests.PorukaSearchRequest, Model.Requests.PorukaUpsertRequest, Model.Requests.PorukaUpsertRequest>
    {
        public PorukaController(ICRUDService<Poruka, PorukaSearchRequest, PorukaUpsertRequest, PorukaUpsertRequest> service) : base(service)
        {
        }
    }
}