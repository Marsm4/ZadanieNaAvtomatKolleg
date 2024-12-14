using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Gruppa
    {
        [Key]
        public int ID_Gruppa { get; set; }
        public string Nomer_Gruppa { get; set; }
        public int? ID_Specialnosti { get; set; }
        public DateTime? God_Priema { get; set; }
    }

}
