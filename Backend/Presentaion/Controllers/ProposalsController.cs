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
    public class ProposalsController : ControllerBase
    {
        private readonly IProposalRepository _repository;

        public ProposalsController(IProposalRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProposals()
        {
            var proposals = await _repository.GetAllAsync();
            return Ok(proposals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProposal(int id)
        {
            var proposal = await _repository.GetByIdAsync(id);
            if (proposal == null)
            {
                return NotFound();
            }
            return Ok(proposal);
        }
                [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProposal(int id)
        {
            var proposal = await _repository.GetByIdAsync(id);
            if (proposal == null)
            {
                return NotFound();
            }

            _repository.Delete(proposal);

            if (await _repository.SaveChangesAsync())
            {
                return NoContent();
            }

            return BadRequest("Could not delete the proposal.");
        }

        [HttpGet("service/{serviceId}")] 
        public async Task<IActionResult> GetProposalsByServiceId(int serviceId)
        {
            var proposals = await _repository.GetByServiceIdAsync(serviceId);
            if (proposals == null || !proposals.Any())
            {
                return NotFound("No proposals found for this service.");
            }
            return Ok(proposals);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProposal([FromBody] Proposal proposal)
        {
            await _repository.AddAsync(proposal);
            if (await _repository.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(GetProposal), new { id = proposal.ProposalId }, proposal);
            }
            return BadRequest("Could not create the proposal.");
        }


    }
}
