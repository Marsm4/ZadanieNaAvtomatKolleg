using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Tip_Zanytia
    {
        [Key] // Определяем первичный ключ
        public string ID_Tipa_zan { get; set; }
        public string Nazvanie { get; set; }
    }
}
