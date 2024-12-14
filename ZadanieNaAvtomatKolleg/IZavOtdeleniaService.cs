using System.Collections.Generic;

namespace ZadanieNaAvtomatKolleg.Interfaces
{
    public interface IZavOtdeleniaService
    {
        IEnumerable<Zav_Otdelenia> GetAll();
        Zav_Otdelenia GetById(int id);
        void Add(Zav_Otdelenia zavOtdelenia);
        void Update(Zav_Otdelenia zavOtdelenia);
        void Delete(int id);
    }
}