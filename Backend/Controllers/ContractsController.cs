using Backend.Models;
using Backend.Repositories;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult GetContracts()
        {
            var contracts = _repository.GetAll();
            return Ok(contracts);
        }

        [HttpGet("{id}")]
        public IActionResult GetContract(int id)
        {
            var contract = _repository.GetById(id);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok(contract);
        }

        [HttpPost]
        public IActionResult CreateContract([FromBody] Contract contract)
        {
            _repository.Add(contract);
            if (_repository.SaveChanges())
            {
                return CreatedAtAction(nameof(GetContract), new { id = contract.ContractId }, contract);
            }
            return BadRequest("Could not create the contract.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContract(int id, [FromBody] Contract updatedContract)
        {
            var contract = _repository.GetById(id);
            if (contract == null)
            {
                return NotFound();
            }

            contract.Status = updatedContract.Status;
            contract.UserId = updatedContract.UserId;
            contract.ServiceId = updatedContract.ServiceId;

            _repository.Update(contract);
            if (_repository.SaveChanges())
            {
                return Ok(contract);
            }

            return BadRequest("Could not update the contract.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContract(int id)
        {
            var contract = _repository.GetById(id);
            if (contract == null)
            {
                return NotFound();
            }

            _repository.Delete(contract);
            if (_repository.SaveChanges())
            {
                return NoContent();
            }

            return BadRequest("Could not delete the contract.");
        }
    }
}
