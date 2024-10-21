using Backend.Context;
using Backend.Models;
using Backend.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace Backend.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly AppDbContext _context;

        public ContractRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contract>> GetAllAsync()
        {
            return await _context.Contracts.ToListAsync();
        }

        public async Task<Contract> GetByIdAsync(int id)
        {
            return await _context.Contracts.FindAsync(id);
        }

        public async Task AddAsync(Contract contract)
        {
            await _context.Contracts.AddAsync(contract);
        }

        public async Task UpdateAsync(Contract contract)
        {
            _context.Contracts.Update(contract); 
        }

        public async Task DeleteAsync(Contract contract)
        {
            _context.Contracts.Remove(contract);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await Task.FromResult(_context.SaveChanges() > 0);
        }
        public async Task<List<Contract>> GetByServiceIdAsync(int serviceId)
        {
            return await _context.Contracts
                .Where(c => c.ServiceId == serviceId)
                .ToListAsync();
        }

        public async Task<List<Contract>> GetByUserIdAsync(int userId)
        {
            return await _context.Contracts
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

    }
}
