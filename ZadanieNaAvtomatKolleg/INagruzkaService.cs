using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieNaAvtomatKolleg
{
    public interface INagruzkaService
    {
        IEnumerable<Nagruzka> GetAll();
        Nagruzka GetById(int id);
        void Add(Nagruzka nagruzka);
        void Update(Nagruzka nagruzka);
        void Delete(int id);
    }
}
