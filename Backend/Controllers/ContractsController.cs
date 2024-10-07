using Backend.Context;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContractsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetContracts()
        {
            var contracts = _context.Contracts.ToList();
            return Ok(contracts);
        }

        [HttpGet("{id}")]
        public IActionResult GetContract(int id)
        {
            var contract = _context.Contracts.Find(id);
            if (contract == null) return NotFound();
            return Ok(contract);
        }

        [HttpPost]
        public IActionResult CreateContract([FromBody] Contract contract)
        {
            _context.Contracts.Add(contract);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetContract), new { id = contract.ContractId }, contract);
        }

    }

}
