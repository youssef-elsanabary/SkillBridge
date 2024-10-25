using Stripe;
using Stripe.Checkout;
using Microsoft.Extensions.Options;

namespace Backend.Utils
{

    public class PaymentService
    {
        private readonly StripeClient _client;

        public PaymentService(StripeClient client)
        {
            _client = client;
        }

        public async Task<Session> CreateCheckoutSession(decimal amount, string currency, string successUrl, string cancelUrl)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(amount * 100),
                        Currency = currency,
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Service Payment"
                        }
                    },
                    Quantity = 1
                }
            },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl
            };

            var service = new SessionService(_client);
            return await service.CreateAsync(options);
        }
    }

}