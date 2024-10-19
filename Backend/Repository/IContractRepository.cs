using Backend.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IContractRepository
    {
        List<Contract> GetAll();
        Contract GetById(int id);
        void Add(Contract contract);
        void Update(Contract contract);
        void Delete(Contract contract);
        bool SaveChanges();
    }
}
