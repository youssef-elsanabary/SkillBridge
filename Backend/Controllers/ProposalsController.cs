using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProposalsController : ControllerBase
    {
        private readonly IProposalRepository _repository;

        public ProposalsController(IProposalRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetProposals()
        {
            var proposals = _repository.GetAll();
            return Ok(proposals);
        }

        [HttpGet("{id}")]
        public IActionResult GetProposal(int id)
        {
            var proposal = _repository.GetById(id);
            if (proposal == null)
            {
                return NotFound();
            }
            return Ok(proposal);
        }

        [HttpPost]
        public IActionResult CreateProposal([FromBody] Proposal proposal)
        {
            _repository.Add(proposal);
            if (_repository.SaveChanges())
            {
                return CreatedAtAction(nameof(GetProposal), new { id = proposal.ProposalId }, proposal);
            }
            return BadRequest("Could not create the proposal.");
        }
    }
}
