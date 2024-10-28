using Backend.BusinessLogic;
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
    public PaymentsController(PaymentService paymentService,  IContractRepository ContractRepository)
    {
        _paymentService = paymentService;
        _repository = ContractRepository;
    }
    
    [HttpPost("checkout-session")]
    public async Task<IActionResult> CreateCheckoutSession(decimal amount, string currency, int ContractId)
    {
        var contract = await _repository.GetByIdAsync(ContractId);

        if (contract == null)
        {
            return NotFound("Contract not found.");
        }

        var session = await _paymentService.CreateCheckoutSession(amount, currency,
            successUrl: "https://localhost:5129/api/success",
            cancelUrl: "https://localhost:5129/api/cancel");


            return Ok(new { id = session.Id });

        }


    }




