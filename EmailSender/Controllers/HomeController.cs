using EmailSender.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmailBussinesLayer.EmailClasses;
using EmailBussinesLayer.Interfaces;
using EmailBussinesLayer.Models;

namespace EmailSender.Controllers
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

        [HttpPost]
        public async Task<IActionResult> EmailPost()
        {

            Message message = new Message()
            {
                Name = "",
                To = "",
                Subject = "",
                Body = ""

            };

            MailGatewayOptions options = new MailGatewayOptions()
            {
                SMTPServer = "",
                Sender = "",
                Password = "",
                SenderName = "Name1"
            };
            
            using (var mailSendr = new MessageGatewayService(options))
            {
                await mailSendr.SendMessage(message);
            }

            return Ok();
        }
    }
}
