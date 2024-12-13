using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Gruppa
    {
        public int ID_Gruppa { get; set; }
        public string Nomer_Gruppa { get; set; }
        public int? ID_Specialnosti { get; set; }
        public DateTime? God_Priema { get; set; }
    }

}
