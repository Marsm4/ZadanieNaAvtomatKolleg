using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Uhebnia_Plan
    {
        [Key]
        public int ID_Uhebnogo_Plana { get; set; }
        public int? ID_Disciplina { get; set; }
        public int? ID_Specialnosti { get; set; }
        public int? Kolihestvo_Hasov { get; set; }
    }

}
