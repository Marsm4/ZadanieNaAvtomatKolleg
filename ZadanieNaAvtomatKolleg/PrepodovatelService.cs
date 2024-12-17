using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using ZadanieNaAvtomatKolleg.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace ZadanieNaAvtomatKolleg
{
    public class PrepodovatelService : IPrepodovatelService
    {
        private readonly ApplicationDbContext _context;

        public PrepodovatelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Prepodovatel> GetAll()
        {
            return _context.Prepodovatel.ToList();
        }

        public Prepodovatel GetById(int id)
        {
            return _context.Prepodovatel.FirstOrDefault(p => p.ID_Prepodovatela == id);
        }

        public void Add(Prepodovatel prepodovatel)
        {
            _context.Prepodovatel.Add(prepodovatel);
            _context.SaveChanges();
        }

        public void Update(Prepodovatel prepodovatel)
        {
            _context.Entry(prepodovatel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var prepodovatel = GetById(id);
            if (prepodovatel != null)
            {
                _context.Prepodovatel.Remove(prepodovatel);
                _context.SaveChanges();
            }
        }
    }
}