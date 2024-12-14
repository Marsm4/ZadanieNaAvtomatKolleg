using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{

    public class Sotrudnik
    {
        [Key] // Определяем первичный ключ
        public int ID_sotrudnika { get; set; }
        public string Familia { get; set; }
        public string Ima { get; set; }
        public string Othestvo { get; set; }
        public DateTime? Data_Rojdenia { get; set; }
    }
}
