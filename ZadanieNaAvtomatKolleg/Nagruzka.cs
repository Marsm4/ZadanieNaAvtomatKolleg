using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Nagruzka
    {
        public int ID_Nagruzki { get; set; }
        public int? ID_Prepodovatela { get; set; }
        public int? ID_Uhebnogo_Plana { get; set; }
        public int? Semestr { get; set; }
    }
}
