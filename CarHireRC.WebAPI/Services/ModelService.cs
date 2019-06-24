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
    public class ModelService : BaseCRUDService<Model.Models.ModelAutomobila, Model.Requests.ModelAutomobilaSearch, Database.Model, Model.Requests.ModelAutomobilaUpsertRequest, Model.Requests.ModelAutomobilaUpsertRequest>
    {
        public ModelService(CarHireRCContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<ModelAutomobila> Get(ModelAutomobilaSearch search)
        {
            var query = _context.Set<Database.Model>().OrderBy(x=>x.Naziv).AsQueryable();

            if (search.ModelId > 0)
            {
                query = query.Where(x => x.ModelId == search.ModelId);
            }
            if (search.ProizvodjacId > 0)
            {
                query = query.Where(x => x.ProizvodjacId == search.ProizvodjacId);
            }
            if (search?.Naziv != null)
            {
                query = query.Where(x => x.Naziv == search.Naziv);
            }

            var list = query.ToList();

            return _mapper.Map<List<Model.Models.ModelAutomobila>>(list);
    }
    }
}
