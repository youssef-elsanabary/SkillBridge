using Backend.Models;
using Backend.Repositories;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContractsController : ControllerBase
    {
        private readonly IContractRepository _repository;

        public ContractsController(IContractRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetContracts()
        {
            var contracts = await _repository.GetAllAsync();
            return Ok(contracts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContract(int id)
        {
            var contract = await _repository.GetByIdAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contract);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContract([FromBody] Contract contract)
        {
            await _repository.AddAsync(contract);
            if (await _repository.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(GetContract), new { id = contract.ContractId }, contract);
            }
            return BadRequest("Could not create the contract.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContract(int id, [FromBody] Contract updatedContract)
        {
            var contract = await _repository.GetByIdAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            contract.Status = updatedContract.Status;
            contract.UserId = updatedContract.UserId;
            contract.ServiceId = updatedContract.ServiceId;
            contract.duration = updatedContract.duration;
            contract.price = updatedContract.price;


            await _repository.UpdateAsync(contract);
            if (await _repository.SaveChangesAsync())
            {
                return Ok(contract);
            }

            return BadRequest("Could not update the contract.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            var contract = await _repository.GetByIdAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(contract);
            if (await _repository.SaveChangesAsync())
            {
                return NoContent();
            }

            return BadRequest("Could not delete the contract.");
        }
       
        [HttpGet("services/{serviceId}")]
        public async Task<IActionResult> GetContractsByServiceId(int serviceId)
        {
            var contracts = await _repository.GetByServiceIdAsync(serviceId);
            if (contracts == null || !contracts.Any())
            {
                return NotFound();
            }
            return Ok(contracts);
        }

       
        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetContractsByUserId(int userId)
        {
            var contracts = await _repository.GetByUserIdAsync(userId);
            if (contracts == null || !contracts.Any())
            {
                return NotFound();
            }
            return Ok(contracts);
        }

    }
}
