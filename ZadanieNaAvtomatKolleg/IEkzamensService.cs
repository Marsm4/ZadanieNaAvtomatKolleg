using System.Collections.Generic;

namespace ZadanieNaAvtomatKolleg.Interfaces
{
    public interface IEkzamensService
    {
        IEnumerable<Ekzamens> GetAll();
        Ekzamens GetById(int id);
        void Add(Ekzamens ekzamens);
        void Update(Ekzamens ekzamens);
        void Delete(int id);
    }
}