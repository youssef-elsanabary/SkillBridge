using Backend.Context; // Your DbContext
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using global::Backend.Context;
namespace Backend.BusinessLogic.Interfaces
{
        public class Repository<T> : IRepository<T> where T : class
        {
            private readonly AppDbContext _context;
            private readonly DbSet<T> _dbSet;

            public Repository(AppDbContext context)
            {
                _context = context;
                _dbSet = context.Set<T>();
            }

            public async Task<List<T>> GetAllAsync()
            {
                return await _dbSet.ToListAsync();
            }

            public async Task<T> GetByIdAsync(int id)
            {
                return await _dbSet.FindAsync(id);
            }

            public async Task AddAsync(T entity)
            {
                await _dbSet.AddAsync(entity);
            }

            public async Task UpdateAsync(T entity)
            {
                _dbSet.Update(entity);
                await SaveChangesAsync();
            }

            public async Task DeleteAsync(T entity)
            {
                _dbSet.Remove(entity);
                await SaveChangesAsync();
            }

            public async Task<bool> SaveChangesAsync()
            {
                return await _context.SaveChangesAsync() > 0;
            }
        }
    }


