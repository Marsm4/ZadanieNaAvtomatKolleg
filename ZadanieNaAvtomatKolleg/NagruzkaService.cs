using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class NagruzkaService
    {
        private readonly ApplicationDbContext _context;

        public NagruzkaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Nagruzka> GetAll()
        {
            return _context.Nagruzka.ToList();
        }

        public Nagruzka GetById(int id)
        {
            return _context.Nagruzka.FirstOrDefault(n => n.ID_Nagruzki == id);
        }

        public void Add(Nagruzka nagruzka)
        {
            _context.Nagruzka.Add(nagruzka);
            _context.SaveChanges();
        }

        public void Update(Nagruzka nagruzka)
        {
            _context.Entry(nagruzka).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var nagruzka = GetById(id);
            if (nagruzka != null)
            {
                _context.Nagruzka.Remove(nagruzka);
                _context.SaveChanges();
            }
        }
    }

}
