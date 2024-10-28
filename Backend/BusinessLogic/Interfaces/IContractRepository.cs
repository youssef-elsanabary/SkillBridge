using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public interface IContractRepository
    {
        Task<List<Contract>> GetAllAsync();
        Task<Contract> GetByIdAsync(int id);
        Task AddAsync(Contract contract);
        Task UpdateAsync(Contract contract);
        Task DeleteAsync(Contract contract);
        Task<bool> SaveChangesAsync();
        Task<List<Contract>> GetByServiceIdAsync(int serviceId);
        Task<List<Contract>> GetByClientIdAsync(int clientId);
        Task<List<Contract>> GetByFreelancerIdAsync(int freelancerId);

        Task<Service> GetServiceByIdAsync(int serviceId);
        Task DeleteServiceByIdAsync(int serviceId);
        Task UpdateAsync(Service service);
        Task<bool> CanCreateContractAsync(int serviceId);
        Task DeleteContractAndServiceAsync(Contract contract);
    }
}
