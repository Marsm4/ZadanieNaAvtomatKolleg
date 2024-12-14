using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public class Disciplina
    {
        [Key] // Определяем первичный ключ
        public int ID_Disciplina { get; set; }
        public string Nazvanie_Disciplina { get; set; }
    }

}
