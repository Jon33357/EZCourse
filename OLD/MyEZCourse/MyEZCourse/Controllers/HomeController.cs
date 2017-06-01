using MyEZCourse.Model;

namespace MyEZCourse.Controllers
{
    public class HomeController : Controller
    {
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

            using (var client = new SmtpClient())
            {
                client.Connect("mail.domain.com");
                client.Authenticate("username", "pass");
                var bodybuilder = new BodyBuilder();
                bodybuilder.HtmlBody = $"<p>{formData.Name} ({formData.Email})</p><p>{formData.Phone}</p><p>{formData.Message}</p>";
                bodybuilder.TextBody = "{ formData.Name} ({formData.Email})\r\n{formData.Phone}\r\n{formData.Message}";

                var message = new MimeMessage();
                message.Body = bodybuilder.ToMessageBody();
                message.From.Add(new MailboxAddress("RM","noreply@study.com"));
                message.To.Add(new MailboxAddress("RM", "noreply@study.com"));
                message.Subject = "Contact Form";
                client.Send(message);
                client.Disconnect(true);

            }




            TempData["Message"] = "Thank You !!!";
            return RedirectToAction("Contact");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
