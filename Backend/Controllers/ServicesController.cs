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
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _repository;

        public ServicesController(IServiceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _repository.GetAllAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _repository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound($"Service with ID {id} not found.");
            }
            return Ok(service);
        }

        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetServicesByUserId(int userId)
        {
            var services = await _repository.GetByUserIdAsync(userId);
            if (services == null || services.Count == 0)
            {
                return NotFound($"No services found for user with ID {userId}.");
            }
            return Ok(services);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] Service service)
        {
            await _repository.AddAsync(service);
            if (await _repository.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(GetServiceById), new { id = service.ServiceId }, service);
            }
            return BadRequest("Could not create the service.");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] Service updatedService)
        {
            var service = await _repository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound($"Service with ID {id} not found.");
            }

            service.Title = updatedService.Title;
            service.Description = updatedService.Description;
            service.Price = updatedService.Price;
            service.UserId = updatedService.UserId;

            await _repository.UpdateAsync(service);

            if (await _repository.SaveChangesAsync())
            {
                return Ok(service);
            }

            return BadRequest("Could not update the service.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _repository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound($"Service with ID {id} not found.");
            }

            await _repository.DeleteAsync(service);

            if (await _repository.SaveChangesAsync())
            {
                return NoContent();
            }

            return BadRequest("Could not delete the service.");
        }
    }
}
