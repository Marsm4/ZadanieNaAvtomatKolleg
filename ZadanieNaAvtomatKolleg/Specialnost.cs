using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Specialnost
    {
        public int ID_Specialnosti { get; set; }
        public string Nomer_Specialnosti { get; set; }
        public string Nazvanie_Specialnosti { get; set; }
        public int? ID_Otdelenia { get; set; }
    }

}
