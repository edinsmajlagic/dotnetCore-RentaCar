using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarHireRC.Model;
using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using CarHireRC.WebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace CarHireRC.WebAPI.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly CarHireRCContext _context;
        private readonly IMapper _mapper;
        public KorisnikService(CarHireRCContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Models.Korisnici Autentificiraj(string username, string password)
        {
            var user = _context.Korisnici.Include("KorisniciUloge.Uloge").FirstOrDefault(x => x.UserName == username);
            if(user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, password);

                if(newHash== user.LozinkaHash)
                {
                    return _mapper.Map<Model.Models.Korisnici>(user);
                }
            }
            return null;
        }

        public List<Model.Models.Korisnici> Get(KorisniciSearchRequest search)
        {
            var query = _context.Set<Database.Korisnici>().AsQueryable();

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
            if (search.DatumRegistracijeOd.HasValue)
            {
                query = query.Where(x => x.DatumRegistracije.Date >= search.DatumRegistracijeOd.Value.Date);
            }
            if (search.DatumRegistracijeDo.HasValue)
            {
                query = query.Where(x => x.DatumRegistracije.Date <= search.DatumRegistracijeDo.Value.Date);
            }
            query = query.Where(x => x.Status == search.Status);

            var list = query.ToList();

            List<Model.Models.Korisnici> result = _mapper.Map<List<Model.Models.Korisnici>>(list);
            foreach (var item in result)
            {
                item.ImePrezime = item.Ime + " " + item.Prezime;

            }

            return result;
        }

        public Model.Models.Korisnici GetById(int Id)
        {
            var entity = _context.Korisnici.Find(Id);
                
            return _mapper.Map<Model.Models.Korisnici>(entity);
        }

        public Model.Models.Korisnici Insert(KorisniciUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnici>(request);

            if (request.Password != request.PasswordPotvrda)
            {
                throw new Exception("Passwordi se ne slažu");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            _context.Korisnici.Add(entity);
            _context.SaveChanges();

            foreach (var uloga in request.Uloge)
            {
                Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge();
                Database.Uloge u = _context.Uloge.FirstOrDefault(x => x.UlogaId == uloga);
                korisniciUloge.UlogaId = u.UlogaId;
                korisniciUloge.KorisnikId = entity.KorisnikId;
                korisniciUloge.DatumIzmjene = DateTime.Now;
                _context.KorisniciUloge.Add(korisniciUloge);
            }
            _context.SaveChanges();

            return _mapper.Map<Model.Models.Korisnici>(entity);
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public Model.Models.Korisnici Update(int Id,KorisniciUpsertRequest request)
        {
            var entity = _context.Korisnici.Include(x=> x.KorisniciUloge).FirstOrDefault(x=>x.KorisnikId==Id);
            _context.Korisnici.Attach(entity);
            _context.Korisnici.Update(entity);
            request.KorisnikId = entity.KorisnikId;

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordPotvrda)
                {
                    throw new Exception("Passwordi se ne slažu");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }

            foreach (var uloga in request.Uloge)
            {
                var u = _context.KorisniciUloge.FirstOrDefault(x => x.UlogaId == uloga && x.KorisnikId == entity.KorisnikId);

                if (u == null)
                {
                    Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge();
                    Database.Uloge ul = _context.Uloge.FirstOrDefault(x => x.UlogaId == uloga);
                    korisniciUloge.UlogaId = ul.UlogaId;
                    korisniciUloge.KorisnikId = entity.KorisnikId;
                    korisniciUloge.DatumIzmjene = DateTime.Now;
                    _context.KorisniciUloge.Add(korisniciUloge);
                }
            }
            _context.SaveChanges();
            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Models.Korisnici>(entity);
        }

        
        
    }
}
