using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public partial class Student
    {
        public int ID_Studenta { get; set; }
        public int? ID_Gruppa { get; set; }
        public string Familia_St { get; set; }
        public string Names_St { get; set; }
        public string Othestvo_St { get; set; }
        public DateTime? Data_Rojdenia { get; set; }
        public string Gorod_Rojdenia { get; set; }
        public string LoginStudent { get; set; }
        public string PasswordStudent { get; set; }
    }

}
