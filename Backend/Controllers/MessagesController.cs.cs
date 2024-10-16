using Backend.Context;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<ChatHub> _hubContext;

        public MessagesController(AppDbContext context, IHubContext<ChatHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [HttpGet]
        public ActionResult<List<Message>> GetMessages()
        {
            return _context.Messages.ToList();
        }

        [HttpPost]
        public async Task<ActionResult<Message>> SendMessage(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();


            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message.SenderId, message.Content);

            return message;
        }
    }
}