using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ZadanieNaAvtomatKolleg.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace ZadanieNaAvtomatKolleg
{
    public class RaspisanieService : IRaspisanieService
    {
        private readonly ApplicationDbContext _context;

        public RaspisanieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Raspisanie> GetAll()
        {
            return _context.Raspisanie.ToList();
        }

        public Raspisanie GetById(int id)
        {
            return _context.Raspisanie.FirstOrDefault(r => r.ID_Raspisanie == id);
        }

        public void Add(Raspisanie raspisanie)
        {
            _context.Raspisanie.Add(raspisanie);
            _context.SaveChanges();
        }

        public void Update(Raspisanie raspisanie)
        {
            _context.Entry(raspisanie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var raspisanie = GetById(id);
            if (raspisanie != null)
            {
                _context.Raspisanie.Remove(raspisanie);
                _context.SaveChanges();
            }
        }
    }
}