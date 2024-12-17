using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class SpecialnostService
    {
        private readonly ApplicationDbContext _context;

        public SpecialnostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Specialnost> GetAll()
        {
            return _context.Specialnost.ToList();
        }

        public Specialnost GetById(int id)
        {
            return _context.Specialnost.FirstOrDefault(s => s.ID_Specialnosti == id);
        }

        public void Add(Specialnost specialnost)
        {
            _context.Specialnost.Add(specialnost);
            _context.SaveChanges();
        }

        public void Update(Specialnost specialnost)
        {
            _context.Entry(specialnost).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var specialnost = GetById(id);
            if (specialnost != null)
            {
                _context.Specialnost.Remove(specialnost);
                _context.SaveChanges();
            }
        }
    }

}
