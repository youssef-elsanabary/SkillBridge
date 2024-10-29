﻿using Backend.BusinessLogic;
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

        [HttpGet("/contracts/services/{serviceId}")]
        public async Task<IActionResult> GetContractByServiceId(int serviceId)
        {
            var contract = await _repository.GetByServiceIdAsync(serviceId);
            if (contract == null || !contract.Any())
            {
                return NotFound();
            }
            return Ok(contract);
        }

        [HttpGet("/contracts/freelancers/{freelancerId}")]
        public async Task<IActionResult> GetContractsByFreelancerId(int freelancerId)
        {
            var contracts = await _repository.GetByFreelancerIdAsync(freelancerId);
            if (contracts == null || !contracts.Any())
            {
                return NotFound("No contracts found for this freelancer.");
            }
            return Ok(contracts);
        }

        [HttpGet("/contracts/clients/{clientId}")]
        public async Task<IActionResult> GetContractsByClientId(int clientId)
        {
            var contracts = await _repository.GetByClientIdAsync(clientId);
            if (contracts == null || !contracts.Any())
            {
                return NotFound("No contracts found for this client.");
            }
            return Ok(contracts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContract([FromBody] Contract contract)
        {
            
            var service = await _repository.GetServiceByIdAsync(contract.ServiceId);
            if (service == null)
            {
                return NotFound("Service not found.");
            }
    
            var existingContract = await _repository.GetContractByServiceIdAsync(contract.ServiceId);
            if (existingContract != null)
            {

            //  //  if (existingContract.Status == ContractStatus.Completed || existingContract.Status == ContractStatus.InProgress && existingContract.Status != ContractStatus.Canceled)
            //  //  {
                   return BadRequest("A contract for this service already exists.");
            //    }
           }

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

            if (contract.Status == ContractStatus.Completed)
            {
                await _repository.DeleteAsync(contract);
                await _repository.DeleteServiceByIdAsync(contract.ServiceId);
                return NoContent();
            }

            contract.Status = updatedContract.Status;
            contract.ClientId = updatedContract.ClientId;
            contract.FreelancerId = updatedContract.FreelancerId;
            contract.ServiceId = updatedContract.ServiceId;
            contract.Duration = updatedContract.Duration;
            contract.Price = updatedContract.Price;

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

            contract.Status = ContractStatus.Canceled;
            var service = await _repository.GetServiceByIdAsync(contract.ServiceId);
            await _repository.DeleteAsync(contract);
            if (service != null)
            {
                service.Status = ServiceStatus.Pending;
                await _repository.UpdateAsync(service);
            }

            return NoContent();
        }
    }
}
