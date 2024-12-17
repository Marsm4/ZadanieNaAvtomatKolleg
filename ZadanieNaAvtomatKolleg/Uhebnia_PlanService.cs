using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Uhebnia_PlanService
    {
        private readonly ApplicationDbContext _context;

        public Uhebnia_PlanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Uhebnia_Plan> GetAll()
        {
            return _context.Uhebnia_Plan.ToList();
        }

        public Uhebnia_Plan GetById(int id)
        {
            return _context.Uhebnia_Plan.FirstOrDefault(u => u.ID_Uhebnogo_Plana == id);
        }

        public void Add(Uhebnia_Plan uhebniaPlan)
        {
            _context.Uhebnia_Plan.Add(uhebniaPlan);
            _context.SaveChanges();
        }

        public void Update(Uhebnia_Plan uhebniaPlan)
        {
            _context.Entry(uhebniaPlan).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var uhebniaPlan = GetById(id);
            if (uhebniaPlan != null)
            {
                _context.Uhebnia_Plan.Remove(uhebniaPlan);
                _context.SaveChanges();
            }
        }
    }

}
