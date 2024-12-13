using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Prepodovatel
    {
        public int ID_Prepodovatela { get; set; }
        public int? ID_Sotrudnika { get; set; }
        public string Obrazovanie { get; set; }
        public string Stepen { get; set; }
        public string Kvalifikacia { get; set; }
        public string Login_Prepod { get; set; }
        public string Password_Prepod { get; set; }
    }

}
