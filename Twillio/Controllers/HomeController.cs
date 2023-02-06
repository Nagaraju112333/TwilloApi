using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Twilio;
using Twilio.Rest.Verify.V2.Service;
using Twillio.Models;

namespace Twillio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //TwillioCall();
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


        public static void TwillioCall()
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = Environment.GetEnvironmentVariable("AC48f2191188263b7f3b4eb5d1c9c0bd95");
            string authToken = Environment.GetEnvironmentVariable("83d6589f4dc53d60022984faa209cc69");

            TwilioClient.Init(accountSid, authToken);

            var verification = VerificationResource.Create(
                to: "+15017122661",
                channel: "sms",
                pathServiceSid: "VAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
            );

            Console.WriteLine(verification.Status);
        }

    }
}