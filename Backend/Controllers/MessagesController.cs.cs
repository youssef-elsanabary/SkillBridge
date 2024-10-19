using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _repository;

        public MessagesController(IMessageRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetMessages()
        {
            var messages = _repository.GetAll();
            return Ok(messages);
        }

        [HttpPost]
        public IActionResult CreateMessage([FromBody] Message message)
        {
            _repository.Add(message);
            if (_repository.SaveChanges())
            {
                return CreatedAtAction(nameof(GetMessages), message);
            }
            return BadRequest("Could not send the message.");
        }
    }
}
