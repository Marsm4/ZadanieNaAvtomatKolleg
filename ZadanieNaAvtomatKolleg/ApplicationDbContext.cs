using Microsoft.EntityFrameworkCore;

namespace ZadanieNaAvtomatKolleg
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Day_Nedelia> Day_Nedelia { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Ekzamens> Ekzamens { get; set; }
        public DbSet<Gruppa> Gruppa { get; set; }
        public DbSet<Nagruzka> Nagruzka { get; set; }
        public DbSet<Otdelenie> Otdelenie { get; set; }
        public DbSet<Prepodovatel> Prepodovatel { get; set; }
        public DbSet<Raspisanie> Raspisanie { get; set; }
        public DbSet<Sotrudnik> Sotrudnik { get; set; }
        public DbSet<Specialnost> Specialnost { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Tip_Zanytia> Tip_Zanytia { get; set; }
        public DbSet<Uhebnia_Plan> Uhebnia_Plan { get; set; }
        public DbSet<Zav_Otdelenia> Zav_Otdelenia { get; set; }
    }
}
