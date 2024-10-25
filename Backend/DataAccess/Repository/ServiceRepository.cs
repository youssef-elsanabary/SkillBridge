using Backend.Context;
using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Backend.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;
        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Service>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<List<Service>> GetByUserIdAsync(int userId)
        {
            return await _context.Services
                                 .Where(s => s.UserId == userId)
                                 .ToListAsync();
        }

        public async Task AddAsync(Service service)
        {
            await _context.Services.AddAsync(service);
        }

        public async Task UpdateAsync(Service service)
        {
            _context.Services.Update(service);
        }

        public async Task DeleteAsync(Service service)
        {
            _context.Services.Remove(service);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public IQueryable<Service> SearchServices(string searchTerm)
        {
            return _context.Services
                .Where(s => s.Title.Contains(searchTerm) || s.Description.Contains(searchTerm));
        }
        public async Task<(List<Service>, int totalCount)> GetPaginatedAsync(int pageNumber, int pageSize)
        {

            var totalCount = await _context.Services.CountAsync();
            var services = await _context.Services
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (services, totalCount);
        }

        public async Task<(List<Service>, int totalCount)> GetPaginatedServicesAsync(int pageNumber, int pageSize, string searchTerm = "")
        {
            var query = string.IsNullOrEmpty(searchTerm) ?
                _context.Services :
                SearchServices(searchTerm);

            var totalCount = await query.CountAsync();
            var services = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (services, totalCount);
        }
    }
}
