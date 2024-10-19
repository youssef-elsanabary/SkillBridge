using Backend.Context;
using Backend.Models;
using Backend.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;

        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Message> GetAll()
        {
            return _context.Messages.ToList();
        }

        public void Add(Message message)
        {
            _context.Messages.Add(message);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
