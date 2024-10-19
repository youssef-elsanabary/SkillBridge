using Backend.Context;
using Backend.Models;
using Backend.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly AppDbContext _context;

        public ContractRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Contract> GetAll()
        {
            return _context.Contracts.ToList();
        }

        public Contract GetById(int id)
        {
            return _context.Contracts.Find(id);
        }

        public void Add(Contract contract)
        {
            _context.Contracts.Add(contract);
        }

        public void Update(Contract contract)
        {
            _context.Contracts.Update(contract);
        }

        public void Delete(Contract contract)
        {
            _context.Contracts.Remove(contract);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
