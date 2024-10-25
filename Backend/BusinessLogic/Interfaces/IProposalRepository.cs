using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public interface IProposalRepository
    {
        Task<List<Proposal>> GetAllAsync();
        Task<Proposal> GetByIdAsync(int id);
        Task<List<Proposal>> GetByServiceIdAsync(int serviceId);
        void Delete(Proposal proposal);
        Task AddAsync(Proposal proposal);
        Task<bool> SaveChangesAsync();
    }
}
