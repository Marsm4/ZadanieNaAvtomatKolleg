using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Zav_Otdelenia
    {
        [Key]
        public int ID_zav_Otdelenia { get; set; }
        public int? ID_Sotrudnika { get; set; }
        public string Obraozvanie { get; set; }
        public string Login_zaved { get; set; }
        public string Passwors_zaved { get; set; }
    }
}