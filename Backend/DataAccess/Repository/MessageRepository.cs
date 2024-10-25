using Backend.Context;
using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;

        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetMessagesAsync(int senderId, int receiverId)
        {
            return await _context.Messages
                                 .Where(m => (m.SenderId == senderId && m.ReceiverId == receiverId) ||
                                             (m.SenderId == receiverId && m.ReceiverId == senderId)) 
                                 //.OrderBy(m => m.Timestamp)
                                             .ToListAsync();
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<List<Message>> GetAllAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task AddAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public async Task UpdateAsync(Message message)
        {
            _context.Messages.Update(message);
        }

        public async Task DeleteAsync(Message message)
        {
            _context.Messages.Remove(message);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
