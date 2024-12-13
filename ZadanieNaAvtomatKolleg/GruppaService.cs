using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class GruppaService
    {
        private readonly ApplicationDbContext _context;

        public GruppaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Gruppa> GetAll()
        {
            return _context.Gruppa.ToList();
        }

        public Gruppa GetById(int id)
        {
            return _context.Gruppa.FirstOrDefault(g => g.ID_Gruppa == id);
        }

        public void Add(Gruppa gruppa)
        {
            _context.Gruppa.Add(gruppa);
            _context.SaveChanges();
        }

        public void Update(Gruppa gruppa)
        {
            _context.Entry(gruppa).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var gruppa = GetById(id);
            if (gruppa != null)
            {
                _context.Gruppa.Remove(gruppa);
                _context.SaveChanges();
            }
        }
    }

}
