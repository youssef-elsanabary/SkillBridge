using Backend.Models;
using System.Threading.Tasks;

namespace Backend.BusinessLogic
{
        public interface IContractService
    {
        Task<Contract> CreateContractAsync(int serviceId);
        Task CompleteContractAsync(int contractId);
        Task CancelContractAsync(int contractId);
        Task<Contract> GetContractByIdAsync(int id);
        Task<IEnumerable<Contract>> GetAllContractsAsync();
    }
    }


