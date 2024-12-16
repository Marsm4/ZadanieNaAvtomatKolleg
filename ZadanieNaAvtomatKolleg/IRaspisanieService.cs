using System.Collections.Generic;

namespace ZadanieNaAvtomatKolleg.Interfaces
{
    public interface IRaspisanieService
    {
        IEnumerable<Raspisanie> GetAll();
        Raspisanie GetById(int id);
        void Add(Raspisanie raspisanie);
        void Update(Raspisanie raspisanie);
        void Delete(int id);
    }
}