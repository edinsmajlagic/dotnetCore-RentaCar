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
    public class RezervacijaRentanjaController : BaseCRUDController<Model.Models.RezervacijaRentanja, Model.Requests.RezervacijaRentanjaSearchRequest, Model.Requests.RezervacijaRentanjaUpsertRequest, Model.Requests.RezervacijaRentanjaUpsertRequest>
    {
        public RezervacijaRentanjaController(ICRUDService<RezervacijaRentanja, RezervacijaRentanjaSearchRequest, RezervacijaRentanjaUpsertRequest, RezervacijaRentanjaUpsertRequest> service) : base(service)
        {
        }
    }
}