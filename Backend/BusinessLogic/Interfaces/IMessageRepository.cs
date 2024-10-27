using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetMessagesAsync(int senderId, int receiverId); 
        Task<Message> GetByIdAsync(int id);
        Task<List<Message>> GetAllAsync(); 
        Task AddAsync(Message message); 
        Task UpdateAsync(Message message); 
        Task DeleteAsync(Message message); 
        Task<bool> SaveChangesAsync();
    }
}
