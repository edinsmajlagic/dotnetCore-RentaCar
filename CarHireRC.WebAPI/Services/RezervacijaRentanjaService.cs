using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using CarHireRC.WebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace CarHireRC.WebAPI.Services
{
    public class RezervacijaRentanjaService : BaseCRUDService<Model.Models.RezervacijaRentanja, Model.Requests.RezervacijaRentanjaSearchRequest, Database.RezervacijaRentanja, Model.Requests.RezervacijaRentanjaUpsertRequest, Model.Requests.RezervacijaRentanjaUpsertRequest>
    {
        public RezervacijaRentanjaService(CarHireRCContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Models.RezervacijaRentanja> Get(RezervacijaRentanjaSearchRequest search)
        {
            var query = _context.Set<Database.RezervacijaRentanja>().Include(x => x.Automobil)
                                                                    .ThenInclude(y => y.Model)
                                                                    .ThenInclude(k => k.Proizvodjac)
                                                                    .Include(f => f.Klijent)
                                                                    .OrderByDescending(x => x.RezervacijaOd)
                                                                    .AsQueryable();

            if (search.AutomobilId > 0)
            {
                query = query.Where(x => x.AutomobilId == search.AutomobilId);
            }
            if (search.KlijentId > 0)
            {
                query = query.Where(x => x.KlijentId == search.KlijentId);
            }
            if (search.ModelId > 0)
            {
                query = query.Where(x => x.Automobil.ModelId == search.ModelId);
            }
            if (search.ProizvodjacId > 0)
            {
                query = query.Where(x => x.Automobil.Model.ProizvodjacId == search.ProizvodjacId);
            }
            if (!string.IsNullOrWhiteSpace(search.Ime))
            {
                var klijent = _context.Klijent.Where(y => y.Ime.StartsWith(search.Ime)).FirstOrDefault();
                if (klijent != null)
                {
                    query = query.Where(x => x.Klijent.Ime.StartsWith(search.Ime));

                }
            }
            if (!string.IsNullOrWhiteSpace(search.Prezime))
            {
                var klijent = _context.Klijent.Where(y => y.Prezime.StartsWith(search.Prezime)).FirstOrDefault();
                if (klijent != null)
                {
                    query = query.Where(x => x.Klijent.Prezime.StartsWith(search.Prezime));
                }
            }
            if (!string.IsNullOrWhiteSpace(search.Username))
            {
                var klijent = _context.Klijent.Where(y => y.UserName.StartsWith(search.Username)).FirstOrDefault();
                if (klijent != null)
                {
                    query = query.Where(x => x.Klijent.UserName.StartsWith(search.Username));

                }
            }
            if (!string.IsNullOrWhiteSpace(search.RegistarskaOznaka))
            {
                var registracija = _context.RegistracijaVozila.Where(y => y.RegistarskeOznake.ToLower().StartsWith(search.RegistarskaOznaka) && y.Status == true).FirstOrDefault();
                if (registracija != null)
                {
                    query = query.Where(x => x.AutomobilId == registracija.AutomobilId);

                }
                else
                    query = query.Where(x => x.AutomobilId == 0);

            }
            if (search.RezervacijaOd.HasValue)
            {
                query = query.Where(x => x.RezervacijaOd.Date >= search.RezervacijaOd.Value.Date);
            }
            if (search.RezervacijaDo.HasValue  )
            {
                query = query.Where(x => x.RezervacijaDo.Date <= search.RezervacijaDo.Value.Date);
            }
            if (search.DatumKreiranja.HasValue)
            {
                query = query.Where(x => x.DatumKreiranja.Date == search.DatumKreiranja.Value.Date);
            }
            if(search.StatusAktivna)
            {
                query = query.Where(x => x.RezervacijaDo.Date >= DateTime.Now.Date);

            }
            query = query.Where(x => x.Otkazana == search.Otkazana);

            //query = query.Where(x => x.VracanjeUposlovnicu == search.VracanjeUposlovnicu);
            //query = query.Where(x => x.KaskoOsiguranje == search.KaskoOsiguranje);

            var list = query.ToList();

            List<Model.Models.RezervacijaRentanja> result = _mapper.Map<List<Model.Models.RezervacijaRentanja>>(list);
            foreach (var item in result)
            {
                item.RezervacijaInformacije = item.DatumKreiranja.ToShortDateString() + " (" + item.VoziloInformacije + ")";
                var klijent = _context.Klijent.FirstOrDefault(x => x.KlijentId == item.KlijentId);
                item.Klijent = klijent.Ime + " " + klijent.Prezime;

                var vozilo = _context.Automobil.Include(y=> y.Model)
                                               .ThenInclude(p=>p.Proizvodjac)
                                               .FirstOrDefault(x => x.AutomobilId == item.AutomobilId);
                var posljednjaRegistracija = _context.RegistracijaVozila
                                                     .FirstOrDefault(x => x.AutomobilId == item.AutomobilId
                                                                       && x.Status);
                item.VoziloInformacije = vozilo.Model.Proizvodjac.Naziv + " " + vozilo.Model.Naziv;
                item.VoziloProizvodjacModel = vozilo.Model.Proizvodjac.Naziv + " " + vozilo.Model.Naziv;

                if (posljednjaRegistracija != null)
                    item.VoziloInformacije =item.VoziloInformacije+ "  (" + posljednjaRegistracija.RegistarskeOznake + ")";
                if(vozilo.SlikaThumb != null)
                item.SlikaThumb = vozilo.SlikaThumb;

                item.CijenaIznajmljivanja = vozilo.CijenaIznajmljivanja;
                item.RezervacijaOdDo = item.RezervacijaOd.ToString() + " - " + item.RezervacijaDo.ToString();
                item.RezervacijaBrojDana = (item.RezervacijaDo - item.RezervacijaOd).Days.ToString();

                Database.Ocjena ocjene = _context.Ocjena.FirstOrDefault(x => x.RezervacijaRentanjaId == item.RezervacijaRentanjaId);
                if (ocjene != null)
                {
                    item.IsOcjenjena = true;
                    item.Ocjena = ocjene.Ocjena1;
                }
                else
                    item.IsOcjenjena = false;

                if (item.LokacijaPreuzimanja == "")
                    item.LokacijaPreuzimanja = "Preuzimanje u poslovnici";
            }

            return result;
        }
        public override Model.Models.RezervacijaRentanja GetById(int id)
        {
            var rezervacija = _context.RezervacijaRentanja.FirstOrDefault(x => x.RezervacijaRentanjaId == id);
            var klijent = _context.Klijent.FirstOrDefault(x => x.KlijentId == rezervacija.KlijentId);
            var vozilo = _context.Automobil.Include(y=> y.Model).ThenInclude(z=>z.Proizvodjac).FirstOrDefault(x => x.AutomobilId == rezervacija.AutomobilId);

            var result = _mapper.Map<Model.Models.RezervacijaRentanja>(rezervacija);
            result.VoziloInformacije = vozilo.Model.Proizvodjac.Naziv + " " + vozilo.Model.Naziv;
            result.VoziloProizvodjacModel = vozilo.Model.Proizvodjac.Naziv + " " + vozilo.Model.Naziv;
            result.RezervacijaInformacije = result.DatumKreiranja.ToShortDateString() + " (" + result.VoziloInformacije + ")";
            result.Klijent = klijent.Ime + " " + klijent.Prezime;


            var posljednjaRegistracija = _context.RegistracijaVozila
                                                 .FirstOrDefault(x => x.AutomobilId == result.AutomobilId
                                                                   && x.Status);

            if (posljednjaRegistracija != null)
                result.VoziloInformacije = result.VoziloInformacije + "  (" + posljednjaRegistracija.RegistarskeOznake + ")";


            if (vozilo.SlikaThumb != null)
                result.SlikaThumb = vozilo.SlikaThumb;
            result.CijenaIznajmljivanja = vozilo.CijenaIznajmljivanja;
            result.RezervacijaOdDo = result.RezervacijaOd.ToString() + " - " + result.RezervacijaDo.ToString();
            result.RezervacijaBrojDana = (result.RezervacijaDo - result.RezervacijaOd).Days.ToString();

            Database.Ocjena ocjene = _context.Ocjena.FirstOrDefault(x => x.RezervacijaRentanjaId == result.RezervacijaRentanjaId);
            if (ocjene != null)
            {
                result.IsOcjenjena = true;
                result.Ocjena = ocjene.Ocjena1;
            }
            else
                result.IsOcjenjena = false;
            if (result.LokacijaPreuzimanja == "")
                result.LokacijaPreuzimanja = "Preuzimanje u poslovnici";

            return result;
        }
    }
}
