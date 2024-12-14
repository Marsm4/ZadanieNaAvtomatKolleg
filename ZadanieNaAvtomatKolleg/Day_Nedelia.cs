using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Day_Nedelia
    {
        [Key] // Определяем первичный ключ
        public string ID_day_Ned { get; set; }
        public string Nazvanie { get; set; }
    }

}
