using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAllMessages()
        {
            var messages = await _repository.GetAllAsync();
            return Ok(messages);
        }

    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var message = await _repository.GetByIdAsync(id);
            if (message == null)
            {
                return NotFound($"Message with ID {id} not found.");
            }
            return Ok(message);
        }

      
        [HttpGet("conversation/{senderId}/{receiverId}")]
        public async Task<IActionResult> GetMessagesBetweenUsers(int senderId, int receiverId)
        {
            var messages = await _repository.GetMessagesAsync(senderId, receiverId);
            if (messages == null || messages.Count == 0)
            {
                return NotFound("No messages found between these users.");
            }
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] Message message)
        {
            await _repository.AddAsync(message);
            if (await _repository.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(GetMessageById), new { id = message.MessageId }, message);
            }
            return BadRequest("Could not create the message.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id, [FromBody] Message updatedMessage)
        {
            var message = await _repository.GetByIdAsync(id);
            if (message == null)
            {
                return NotFound($"Message with ID {id} not found.");
            }

            message.Content = updatedMessage.Content;
          //  message.Timestamp = updatedMessage.Timestamp;

            await _repository.UpdateAsync(message);

            if (await _repository.SaveChangesAsync())
            {
                return Ok(message);
            }

            return BadRequest("Could not update the message.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _repository.GetByIdAsync(id);
            if (message == null)
            {
                return NotFound($"Message with ID {id} not found.");
            }

            await _repository.DeleteAsync(message);

            if (await _repository.SaveChangesAsync())
            {
                return NoContent();
            }

            return BadRequest("Could not delete the message.");
        }
    }
}
