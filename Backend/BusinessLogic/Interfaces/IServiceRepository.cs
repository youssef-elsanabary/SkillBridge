using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAllAsync(); 
        Task<Service> GetByIdAsync(int id);
        Task<List<Service>> GetByUserIdAsync(int userId); 
        Task AddAsync(Service service); 
        Task UpdateAsync(Service service); 
        Task DeleteAsync(Service service); 
        Task<bool> SaveChangesAsync();
        IQueryable<Service> SearchServices(string searchTerm);
        Task<(List<Service>, int totalCount)> GetPaginatedServicesAsync(int pageNumber, int pageSize, string searchTerm = "");
    }
}
