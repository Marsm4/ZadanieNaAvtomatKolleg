using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    [Table("Prepodovatel")]
    public class Prepodovatel
    {
        [Key]
        public int ID_Prepodovatela { get; set; }
        public int? ID_Sotrudnika { get; set; }
        public string Obrozovanie { get; set; } // Исправлено на "Obrozovanie"
        public string Stepen { get; set; }
        public string Kfalificacia { get; set; } // Исправлено на "Kfalificacia"
        public string Login_Prepod { get; set; }
        public string Password_Prepod { get; set; }
    }
}


