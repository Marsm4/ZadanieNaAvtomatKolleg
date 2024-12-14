using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Ekzamens
    {
        [Key]
        public int ID_Ekzamena { get; set; }
        public int ID_Uhebnogo_Plana { get; set; }
        public int ID_Prepodovatela { get; set; }
        public int ID_Studenta { get; set; }
        public DateTime Data_Provedenia { get; set; }
        public int Nomer_Kabineta { get; set; }
        public int Ocenka { get; set; }
    }

}
