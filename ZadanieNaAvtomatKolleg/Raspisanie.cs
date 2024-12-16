using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    [Table("Raspisanie")]
    public class Raspisanie
    {
        [Key]
        public int ID_Raspisanie { get; set; }
        public int? ID_Gruppa { get; set; }
        public int? ID_Nagruzka { get; set; }
        public int? Nomer_kabineta { get; set; }
        public int? Nomer_para { get; set; }
        public string ID_Day_Nedelia { get; set; }
        public string ID_tip_Zanania { get; set; }
    }

}
