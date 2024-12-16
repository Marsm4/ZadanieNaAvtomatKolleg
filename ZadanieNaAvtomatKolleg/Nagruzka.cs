using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    [Table("Nagruzka")]
    public class Nagruzka
    {
        [Key]
        public int ID_Nagruzki { get; set; }
        public int? ID_Prepodovatela { get; set; }
        public int? ID_Uhebnogo_Plana { get; set; }
        public int? Semestr { get; set; }
    }
}
