using Backend.Context;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicesController(AppDbContext context)
        {
            _context = context;
        }

        // Get all services
        [HttpGet]
        public ActionResult<List<Service>> GetServices()
        {
            return _context.Services.ToList();
        }

        // Get a single service by ID
        [HttpGet("{id}")]
        public ActionResult<Service> GetServiceById(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound("Service not found.");
            }
            return service;
        }

        // Create a new service
        [HttpPost]
        public ActionResult<Service> CreateService(Service service)
        {
            // Set CreatedDate to current date if not provided
            service.CreatedDate = DateTime.UtcNow;

            _context.Services.Add(service);
            _context.SaveChanges();

            // Returns the newly created service with its ID
            return CreatedAtAction(nameof(GetServiceById), new { id = service.ServiceId }, service);
        }

        // Update an existing service by ID
        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, Service updatedService)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound("Service not found.");
            }

            // Update fields
            service.Title = updatedService.Title;
            service.Description = updatedService.Description;
            service.Price = updatedService.Price;
            service.Category = updatedService.Category;
            service.Status = updatedService.Status;
            service.UserId = updatedService.UserId;

            _context.SaveChanges();
            return NoContent(); // Success with no content response
        }

        // Delete a service by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound("Service not found.");
            }

            _context.Services.Remove(service);
            _context.SaveChanges();
            return NoContent(); // Success with no content response
        }
    }
}
