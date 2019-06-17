using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using CarHireRC.WebAPI.Database;

namespace CarHireRC.WebAPI.Services
{
    public class RacunService : BaseCRUDService<Model.Models.Racun, Model.Requests.RacunSearchRequest, Database.Racun, Model.Requests.RacunUpsertRequest, Model.Requests.RacunUpsertRequest>
    {
        public RacunService(CarHireRCContext context, IMapper mapper) : base(context, mapper)
        {
        }

      
    }
}
