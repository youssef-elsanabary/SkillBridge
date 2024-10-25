using Backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PaymentsController : ControllerBase
{
    private readonly PaymentService _paymentService;

    public PaymentsController(PaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost("checkout-session")]
    public async Task<IActionResult> CreateCheckoutSession(decimal amount, string currency)
    {
        var session = await _paymentService.CreateCheckoutSession(amount, currency,
            successUrl: "https://localhost:5129/api/success",
            cancelUrl: "https://localhost:5129/api/cancel");

        return Ok(new { id = session.Id });
    }
}




