using System.Collections.Generic;

namespace ZadanieNaAvtomatKolleg.Interfaces
{
    public interface IPrepodovatelService
    {
        IEnumerable<Prepodovatel> GetAll();
        Prepodovatel GetById(int id);
        void Add(Prepodovatel prepodovatel);
        void Update(Prepodovatel prepodovatel);
        void Delete(int id);
    }
}