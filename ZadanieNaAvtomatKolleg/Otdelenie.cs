using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Otdelenie
    {
        [Key] // Определяем первичный ключ
        public int ID_Otdelenia { get; set; }
        public string Nazvanie_Otdelenia { get; set; }
        public int? ID_Zav_Otdelenia { get; set; }
    }
}
