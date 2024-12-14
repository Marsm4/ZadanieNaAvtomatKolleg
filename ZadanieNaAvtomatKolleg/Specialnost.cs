using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Specialnost
    {
        [Key] // Определяем первичный ключ
        public int ID_Specialnosti { get; set; }
        public string Nomer_Specialnosti { get; set; }
        public string Nazvanie_Specialnosti { get; set; }
        public int? ID_Otdelenia { get; set; }
    }
}
