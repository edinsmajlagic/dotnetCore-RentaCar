using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using CarHireRC.WebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace CarHireRC.WebAPI.Services
{
    public class KlijentService : BaseCRUDService<Model.Models.Klijent, Model.Requests.KlijentSearchRequest, Database.Klijent, Model.Requests.KlijentUpsertRequest, Model.Requests.KlijentUpsertRequest>
    {
        public KlijentService(CarHireRCContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Models.Klijent> Get(KlijentSearchRequest search)
        {
            var query = _context.Set<Database.Klijent>().AsQueryable();

         
            if (search.GradId > 0)
            {
                query = query.Where(x => x.GradId == search.GradId);
            }
            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Ime.ToLower().StartsWith(search.Ime));
            }
            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                query = query.Where(x => x.Prezime.ToLower().StartsWith(search.Prezime));
            }
            if (!string.IsNullOrWhiteSpace(search?.UserName))
            {
                query = query.Where(x => x.UserName.ToLower().StartsWith(search.UserName));
            }
            if(search.DatumRegistracijeOd.HasValue)
            {
                query = query.Where(x => x.DatumRegistracije.Date >= search.DatumRegistracijeOd.Value.Date);
            }
            if (search.DatumRegistracijeDo.HasValue)
            {
                query = query.Where(x => x.DatumRegistracije.Date <= search.DatumRegistracijeDo.Value.Date);
            }
            query = query.Where(x => x.Status == search.Status);


            var list = query.ToList();

            return _mapper.Map<List<Model.Models.Klijent>>(list);
        }
    }
}
