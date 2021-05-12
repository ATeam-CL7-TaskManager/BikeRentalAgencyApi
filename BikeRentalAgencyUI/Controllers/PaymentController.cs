using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace BikeRentalAgencyUI.Controllers
{
    public class PaymentsController : Controller
    {
        public PaymentsController()
        {
            StripeConfiguration.ApiKey = "pk_test_51IqHj4AGeQfZJrspPlPqDykATINQ5VGzHC0AeWdcn0DwKZA4Y1AQMz77Yifrqtv7IrSosGIg5r2gGJNrCBscsWpl00KeR79rAv";
        }

        [HttpPost("create-checkout-session")]
        public ActionResult CreateCheckoutSession()
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
        {
          "card",
        },
                LineItems = new List<SessionLineItemOptions>
        {
          new SessionLineItemOptions
          {
            PriceData = new SessionLineItemPriceDataOptions
            {
              UnitAmount = 2000,
              Currency = "usd",
              ProductData = new SessionLineItemPriceDataProductDataOptions
              {
                Name = "T-shirt",
              },

            },
            Quantity = 1,
          },
        },
                Mode = "payment",
                SuccessUrl = "https://example.com/success",
                CancelUrl = "https://example.com/cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return Json(new { id = session.Id });
        }
    }
}
