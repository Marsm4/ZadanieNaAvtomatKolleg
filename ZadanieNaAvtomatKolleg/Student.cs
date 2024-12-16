using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    [Table("Student")] // Указываем имя таблицы в базе данных
    public partial class Student
    {
        [Key]
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
