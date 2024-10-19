using Backend.Context;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult GetServices()
        {
            var services = _repository.GetAll();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public IActionResult GetServiceById(int id)
        {
            var service = _repository.GetById(id);
            if (service == null)
            {
                return NotFound("Service not found.");
            }
            return Ok(service);
        }

        [HttpPost]
        public IActionResult CreateService([FromBody] Service service)
        {
            service.CreatedDate = DateTime.UtcNow;
            _repository.Add(service);
            if (_repository.SaveChanges())
            {
                return CreatedAtAction(nameof(GetServiceById), new { id = service.ServiceId }, service);
            }
            return BadRequest("Could not save the service.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, [FromBody] Service updatedService)
        {
            var service = _repository.GetById(id);
            if (service == null)
            {
                return NotFound("Service not found.");
            }

            service.Title = updatedService.Title;
            service.Description = updatedService.Description;
            service.Price = updatedService.Price;
            service.Category = updatedService.Category;
            service.Status = updatedService.Status;
            service.UserId = updatedService.UserId;

            _repository.Update(service);
            if (_repository.SaveChanges())
            {
                return NoContent();
            }
            return BadRequest("Could not update the service.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var service = _repository.GetById(id);
            if (service == null)
            {
                return NotFound("Service not found.");
            }

            _repository.Delete(service);
            if (_repository.SaveChanges())
            {
                return NoContent();
            }
            return BadRequest("Could not delete the service.");
        }
    }
}

