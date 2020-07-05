using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.BillingPortal;
using Task_6.Models;

namespace Task_6.Controllers
{
    public class HomeController : Controller
    {
        private int amount = 100;
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
            StripeConfiguration.ApiKey = _configuration["Stripe:sk_test_51Gzaa1HAh8lBnQxza9cOAzY7LbfgQ4FWX2sYqiuHsoVWJg4mNDppueQkAVd0XIPU4GhcrNBca8aemNgr24m4jDv200ooFw0Bhz"];
        }

        public IActionResult Index()
        {
            ViewBag.PaymentAmount = amount;
            var subscriptionService = new SubscriptionService();
            //var subscription = subscriptionService.Create(subscriptionOptions);

            ViewBag.stripeKey = _configuration["Stripe:pk_test_51Gzaa1HAh8lBnQxzdxo2zIn3mzr0lkJiQcsQowOZSd1S85Sou79t2Ub8OwI1lkGcAcgHYxJeB3wIhmFimN9DdKnD00BesCjDg3"];
            //ViewBag.subscription = subscription.ToJson();
            return View();
        }

        [HttpPost]
        public IActionResult CreateSession()
        {   //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
            //sk_test_51Gzaa1HAh8lBnQxza9cOAzY7LbfgQ4FWX2sYqiuHsoVWJg4mNDppueQkAVd0XIPU4GhcrNBca8aemNgr24m4jDv200ooFw0Bhz
            StripeConfiguration.ApiKey = "sk_test_51Gzaa1HAh8lBnQxza9cOAzY7LbfgQ4FWX2sYqiuHsoVWJg4mNDppueQkAVd0XIPU4GhcrNBca8aemNgr24m4jDv200ooFw0Bhz";
            var options = new SessionCreateOptions
            {
                Customer = "cus_HYlpCpA6CGr5Xn",
                ReturnUrl = "https://localhost:44318/",
            };
            var service = new SessionService();
            var session = service.Create(options);
            return Redirect(session.Url);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subscribe(string email, string plan, string stripeToken)
        {
            StripeConfiguration.ApiKey = "sk_test_51Gzaa1HAh8lBnQxza9cOAzY7LbfgQ4FWX2sYqiuHsoVWJg4mNDppueQkAVd0XIPU4GhcrNBca8aemNgr24m4jDv200ooFw0Bhz";
            var customerOptions = new CustomerCreateOptions
            {
                Email = email,
                Source = stripeToken,
            };

            var customerService = new CustomerService();
            var customer = customerService.Create(customerOptions);

            var planId="";

            if (plan == "Basic Plan") {
                planId = "price_1GzePPHAh8lBnQxzEOztVJZo";
            }
            else if (plan == "Standard Plan")
            {
                planId = "price_1GzeOyHAh8lBnQxz1uv2YPwm";
            }
            else if (plan == "Premium Plan") {
                planId = "price_1GzePbHAh8lBnQxzC9f5F9oh";
            }

            var subscriptionOptions = new SubscriptionCreateOptions
            {
                Customer = customer.Id,
                Items = new List<SubscriptionItemOptions>
                {
                    new SubscriptionItemOptions
                    {
                        Plan = planId
                    },
                },
            };
            subscriptionOptions.AddExpand("latest_invoice.payment_intent");

            var subscriptionService = new SubscriptionService();
            var subscription = subscriptionService.Create(subscriptionOptions);

            ViewBag.stripeKey = _configuration["Stripe:pk_test_51Gzaa1HAh8lBnQxzdxo2zIn3mzr0lkJiQcsQowOZSd1S85Sou79t2Ub8OwI1lkGcAcgHYxJeB3wIhmFimN9DdKnD00BesCjDg3"];
            ViewBag.subscription = subscription.ToJson();

            return View("SubscribeResult");
        }

        [HttpPost]
        public string TogglePause(string togglePause)
        {   //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
            //sk_test_51Gzaa1HAh8lBnQxza9cOAzY7LbfgQ4FWX2sYqiuHsoVWJg4mNDppueQkAVd0XIPU4GhcrNBca8aemNgr24m4jDv200ooFw0Bhz
            StripeConfiguration.ApiKey = "sk_test_51Gzaa1HAh8lBnQxza9cOAzY7LbfgQ4FWX2sYqiuHsoVWJg4mNDppueQkAVd0XIPU4GhcrNBca8aemNgr24m4jDv200ooFw0Bhz";
            var msg = "";
            
            if (togglePause == "pause")
            {
                var options = new SubscriptionUpdateOptions
                {
                    PauseCollection = new SubscriptionPauseCollectionOptions
                    {
                        Behavior = "mark_uncollectible",
                    },
                };
                var service = new SubscriptionService();
                service.Update("sub_HZ5QvvcLgLx8vW", options);
                msg = "Subscription paused";
            }

            else if(togglePause == "resume"){
                var options = new SubscriptionUpdateOptions();
                options.AddExtraParam("pause_collection", "");
                var service = new SubscriptionService();
                service.Update("sub_HZ5QvvcLgLx8vW", options);
                msg = "Subscription resumed";
            }
            //ViewBag.message = msg;
            return msg;
        }

        [HttpPost]
        public string Refund(string toggleRefund)
        {   //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
            //sk_test_51Gzaa1HAh8lBnQxza9cOAzY7LbfgQ4FWX2sYqiuHsoVWJg4mNDppueQkAVd0XIPU4GhcrNBca8aemNgr24m4jDv200ooFw0Bhz
            StripeConfiguration.ApiKey = "sk_test_51Gzaa1HAh8lBnQxza9cOAzY7LbfgQ4FWX2sYqiuHsoVWJg4mNDppueQkAVd0XIPU4GhcrNBca8aemNgr24m4jDv200ooFw0Bhz";
            var msg = "";

            if (toggleRefund == "refund")
            {
                var refunds = new RefundService();
                var refundOptions = new RefundCreateOptions
                {
                    PaymentIntent = "pi_1GzxFMHAh8lBnQxzpA2OSATN"
                };
                var refund = refunds.Create(refundOptions);
                msg = "Payment refunded successfully";
            }

            else if (toggleRefund == "cancelRefund")
            {
                var service = new PaymentIntentService();
                var options = new PaymentIntentCancelOptions { };
                var intent = service.Cancel("pi_1GzxFMHAh8lBnQxzpA2OSATN", options);
                msg = "Payment refund cancelled";
            }
            //ViewBag.message = msg;
            return msg;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
