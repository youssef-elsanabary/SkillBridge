using Backend.BusinessLogic;
using Backend.Context;
using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<Contract?> GetContractByServiceIdAsync(int serviceId)
        {
            return await _context.Contracts
                .Where(c => c.ServiceId == serviceId)
                .FirstOrDefaultAsync();
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
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Contract>> GetByServiceIdAsync(int serviceId)
        {
            return await _context.Contracts
                .Where(c => c.ServiceId == serviceId)
                .ToListAsync();
        }

        public async Task<List<Contract>> GetByClientIdAsync(int clientId)
        {
            return await _context.Contracts
                .Where(c => c.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<List<Contract>> GetByFreelancerIdAsync(int freelancerId)
        {
            return await _context.Contracts
                .Where(c => c.FreelancerId == freelancerId)
                .ToListAsync();
        }

     
        public async Task<bool> CanCreateContractAsync(int serviceId)
        {
            var service = await _context.Services.FindAsync(serviceId);
            return service != null && service.Status == ServiceStatus.Assigned;
        }

       
        public async Task DeleteContractAndServiceAsync(Contract contract)
        {
            var service = await _context.Services.FindAsync(contract.ServiceId);

           
            _context.Contracts.Remove(contract);

         
            if (service != null)
            {
                if (contract.Status == ContractStatus.Completed)
                {
                    _context.Services.Remove(service);
                }
                else if (contract.Status == ContractStatus.Canceled)
                {
                    service.Status = ServiceStatus.Pending; 
                    _context.Services.Update(service);
                }
            }
        }
        public async Task<Service> GetServiceByIdAsync(int serviceId)
        {
            return await _context.Services.FindAsync(serviceId);
        }

        public async Task DeleteServiceByIdAsync(int serviceId)
        {
            var service = await _context.Services.FindAsync(serviceId);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }

    }
}
