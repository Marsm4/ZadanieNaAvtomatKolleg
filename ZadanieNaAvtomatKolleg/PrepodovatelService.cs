using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class PrepodovatelService
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
            _context.Entry(prepodovatel).State = EntityState.Modified;
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
