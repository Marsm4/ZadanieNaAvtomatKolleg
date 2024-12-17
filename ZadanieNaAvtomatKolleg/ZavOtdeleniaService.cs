using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ZadanieNaAvtomatKolleg.Interfaces;

namespace ZadanieNaAvtomatKolleg
{
    public class ZavOtdeleniaService : IZavOtdeleniaService
    {
        private readonly ApplicationDbContext _context;

        public ZavOtdeleniaService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Реализация методов интерфейса IZavOtdeleniaService
        public IEnumerable<Zav_Otdelenia> GetAll()
        {
            return _context.Zav_Otdelenia.ToList();
        }

        public Zav_Otdelenia GetById(int id)
        {
            return _context.Zav_Otdelenia.FirstOrDefault(z => z.ID_zav_Otdelenia == id);
        }

        public void Add(Zav_Otdelenia zavOtdelenia)
        {
            _context.Zav_Otdelenia.Add(zavOtdelenia);
            _context.SaveChanges();
        }

        public void Update(Zav_Otdelenia zavOtdelenia)
        {
            _context.Entry(zavOtdelenia).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var zavOtdelenia = GetById(id);
            if (zavOtdelenia != null)
            {
                _context.Zav_Otdelenia.Remove(zavOtdelenia);
                _context.SaveChanges();
            }
        }
    }
}