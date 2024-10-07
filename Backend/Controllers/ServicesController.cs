using Backend.Context;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        
        [HttpPost]
        public ActionResult<Service> CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return service;
        }
    }

}
