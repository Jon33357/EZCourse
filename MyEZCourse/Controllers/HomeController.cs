using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyEZCourse.Model;
using MailKit.Net.Smtp;
using MimeKit;
using MyEZCourse.Services;
using Microsoft.Extensions.Options;

namespace MyEZCourse.Controllers
{
    public class HomeController : Controller
    {
        readonly Smtp _smtpService;
        readonly ContactOptions _contactOptions;

        public HomeController(Services.Smtp smtpService, IOptions<ContactOptions> contactOptions)
        {
            _smtpService = smtpService;
            _contactOptions = contactOptions.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            //1. Do Something
            var htmlBody = $"<p>{formData.Name} ({formData.Email})</p><p>{formData.Phone}</p><p>{formData.Message}</p>";
            var textBody = "{ formData.Name} ({formData.Email})\r\n{formData.Phone}\r\n{formData.Message}";

            _smtpService.SendSingle("Contact Form", htmlBody, textBody, _contactOptions.ContactToName, _contactOptions.ContactToAddress,
                _contactOptions.ContactFromName, _contactOptions.ContactFromAddress);

            //2. Set Message
            TempData["Message"] = "Thank You !!!";

            //3. Redirect the browser
            return RedirectToAction("Contact");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
