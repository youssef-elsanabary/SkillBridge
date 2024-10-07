using Backend.Context;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProposalsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProposals()
        {
            var proposals = _context.Proposals.ToList();
            return Ok(proposals);
        }

        [HttpGet("{id}")]
        public IActionResult GetProposal(int id)
        {
            var proposal = _context.Proposals.Find(id);
            if (proposal == null) return NotFound();
            return Ok(proposal);
        }

        [HttpPost]
        public IActionResult CreateProposal([FromBody] Proposal proposal)
        {
            _context.Proposals.Add(proposal);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProposal), new { id = proposal.ProposalId }, proposal);
        }

    }

}
