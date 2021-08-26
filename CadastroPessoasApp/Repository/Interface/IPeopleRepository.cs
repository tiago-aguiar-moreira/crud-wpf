using CadastroPessoasApp.Model;
using System.Collections.Generic;

namespace CadastroPessoasApp.Repository.Interface
{
    public interface IPeopleRepository
    {
        IEnumerable<PeopleRecord> GetAll();
        PeopleRecord Get(int id);
        void AddPeople(PeopleRecord pessoa);
        void UpdatePeople(PeopleRecord pessoa);
        void RemovePeople(int id);
    }
}
