using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ZadanieNaAvtomatKolleg.Interfaces;

namespace ZadanieNaAvtomatKolleg
{
    public class EkzamensService : IEkzamensService
    {
        private readonly ApplicationDbContext _context;

        public EkzamensService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ekzamens> GetAll()
        {
            return _context.Ekzamens.ToList();
        }

        public Ekzamens GetById(int id)
        {
            return _context.Ekzamens.FirstOrDefault(e => e.ID_Ekzamena == id);
        }

        public void Add(Ekzamens ekzamens)
        {
            _context.Ekzamens.Add(ekzamens);
            _context.SaveChanges();
        }

        public void Update(Ekzamens ekzamens)
        {
            _context.Entry(ekzamens).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ekzamens = GetById(id);
            if (ekzamens != null)
            {
                _context.Ekzamens.Remove(ekzamens);
                _context.SaveChanges();
            }
        }
    }
}