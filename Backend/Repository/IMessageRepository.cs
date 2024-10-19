using Backend.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IMessageRepository
    {
        List<Message> GetAll();
        void Add(Message message);
        bool SaveChanges();
    }
}
