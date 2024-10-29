using Backend.BusinessLogic;
using Backend.Models;
using Backend.Repositories;
using Backend.Repository;
using Backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Diagnostics.Contracts;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PaymentsController : ControllerBase
{
    private readonly PaymentService _paymentService;
    private readonly IContractRepository _repository;

    public PaymentsController(PaymentService paymentService, IContractRepository contractRepository)
    {
        _paymentService = paymentService;
        _repository = contractRepository;
    }

    [HttpPost("checkout-session")]
    public async Task<IActionResult> CreateCheckoutSession(decimal amount, string currency, int contractId)
    {
        // contractid 
        var contract = await _repository.GetByIdAsync(contractId);
        if (contract == null)
        {
            return NotFound("Contract not found.");
        }

        if (contract.Status != ContractStatus.Completed)
        {
            return BadRequest("Payment is not allowed for contracts that are not completed.");
        }

    
        var session = await _paymentService.CreateCheckoutSession(amount, currency,
            successUrl: "https://localhost:5129/api/success",
            cancelUrl: "https://localhost:5129/api/cancel");

        return Ok(new { id = session.Id });
    }

}
