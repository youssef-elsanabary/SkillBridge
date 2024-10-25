using Backend.Context;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly AppDbContext _context;

        public ProposalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Proposal>> GetAllAsync()
        {
            return await Task.FromResult(_context.Proposals.ToList());
        }

        public async Task<Proposal> GetByIdAsync(int id)
        {
            return await Task.FromResult(_context.Proposals.Find(id));
        }
        public void Delete(Proposal proposal)
        {
            _context.Proposals.Remove(proposal);
        }

        public async Task<List<Proposal>> GetByServiceIdAsync(int serviceId) 
        {
            return await Task.FromResult(_context.Proposals.Where(p => p.ServiceId == serviceId).ToList());
        }

        public async Task AddAsync(Proposal proposal)
        {
            await Task.Run(() => _context.Proposals.Add(proposal));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await Task.FromResult(_context.SaveChanges() > 0);
        }
    }
}
