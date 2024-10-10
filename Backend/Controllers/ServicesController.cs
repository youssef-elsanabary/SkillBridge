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

        [HttpGet]
        public ActionResult<List<Service>> GetServices()
        {
            return _context.Services.ToList();
        }

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

        [HttpPost]
        public ActionResult<Service> CreateService(Service service)
        {
            service.CreatedDate = DateTime.UtcNow;

            _context.Services.Add(service);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetServiceById), new { id = service.ServiceId }, service);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, Service updatedService)
        {
            var service = _context.Services.Find(id);
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

            _context.SaveChanges();
            return NoContent(); 
        }

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
            return NoContent(); 
        }
    }
}
